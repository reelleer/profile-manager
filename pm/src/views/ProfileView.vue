<script setup>
import { ref, computed, unref } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, minLength } from '@vuelidate/validators'
import { get, setUrl, put } from '../lib/fetch.js'
import PersonalInfo from '../components/PersonalInfo.vue'
import StudiesList from '../components/StudiesList.vue'
import StudyForm from '../components/StudyForm.vue'
import PollForm from '../components/PollForm.vue'
import { useSession } from '../composables/session.js'

const { userId } = useSession()

const router = useRouter()

const url = setUrl('/profiles')

const ready = ref(false)
const sending = ref(false)
const showForm = ref(false)

const profile = ref({})

const rules = {
  studies: { required, minLength: minLength(1) },
}

const v = useVuelidate(
  rules,
  profile,
  { $autoDirty: true }
)

const showStudiesError = computed(
  () => v.value.studies.$error && !showForm.value
)

const getProfile = () => get(url(userId.value)) 
  .then(res => {
    profile.value = res.data
    ready.value = true

    if(!profile.value.studies || !profile.value.studies.length)
      onStudyNew()
  })
 

const onInfoSave = (info) => {
  profile.value.personalInfo = info
}

let studyId

let studyForm

const onStudyNew = () => {
  studyId = 0

  studyForm = {
    type: '',
    country: '',
    university: '',
    study: '',
    begin: '',
    end: ''
  }
  
  showForm.value = true
}

const onStudyCancel = () => {
  showForm.value = false
}

const onStudySave = (data) => {
  if(studyId === 0)
    profile.value.studies.push({
      id: Symbol(data.study),
      ...data
    })
  else {
    const item = profile.value.studies.find(s => s.id === studyId)

    if(item) {
      item.type = data.type
      item.country = data.country
      item.university = data.university
      item.study = data.study
      item.begin = data.begin
      item.end = data.end
    }
  }

  showForm.value = false
}

const onStudyEdit = (id) => {
  studyForm = profile.value.studies.find(s => s.id === id)

  if(studyForm) {
    console.log(studyForm)
    studyId = id
    showForm.value = true
  }
}

const onStudyRemove = id => {
  const item = profile.value.studies.find(s => s.id === id)

  const index = profile.value.studies.indexOf(item)

  if(index >= 0)
    profile.value.studies.splice(index, 1)
}

const onPollSave = async (poll) => {
  profile.value.poll = poll
}

let isSending = false

const profileSave = async () => {
  if(isSending) return

  const isValid = await v.value.$validate()

  if(!isValid) {
    alert('Lo datos no se pueden guardar, revise los compos con errores.')
    return
  }

  isSending = true

  try {
    const data = { ... profile.value }
    data.id = userId.value

    await put(url(userId.value), data)       

    router.push({ name: 'ProfileEnd' })
  } catch (error) {
    console.log(error)
    alert(`Nos se pudo guardar el perfil: ${error.message}`)
  }

  isSending = false
}

getProfile()
</script>
<template>
  <p v-if="!ready">Estamos cargando tu perfil.</p>
  <div v-else>
    <h1 class="h2 py-3">Rellene el Formulario para actualizar sus datos</h1>
    <PersonalInfo
      :info="profile.personalInfo"
      @infoSave="onInfoSave"
    ></PersonalInfo>
    <h2 class="h3 border-bottom border-dark py-2">Historial Académico</h2>
    <p v-show="showStudiesError" class="my-4 text-danger">
      Debe agregar al menos un estudio realizado con el programa Erasmus.
    </p>
    <StudiesList
      v-if="!showForm"
      :items="profile.studies"
      @studyEdit="onStudyEdit"
      @studyRemove="onStudyRemove"
    ></StudiesList>
    <StudyForm
      v-if="showForm"
      :study="studyForm"
      @study:cancel="onStudyCancel"
      @study:save="onStudySave"
    ></StudyForm>
    <button v-if="!showForm" @click="onStudyNew" class="btn btn-primary">
      <svg width="19" height="18" fill="currentColor">
        <use xlink:href="#plus-square" />
      </svg>
      Agregar
    </button>
    <PollForm v-bind="profile.poll" @poll-save="onPollSave"></PollForm>
    <div class="d-flex justify-content-center my-4">
      <button class="btn btn-primary btn-lg" @click="profileSave">
        <svg
          class="me-1"
          :class="{ 'color-spin': sending }"
          fill="currentColor"
          height="18"
          role="button"
          width="18"
          >
          <use xlink:href="#send" />
        </svg>
          Actualizar
      </button>
    </div>
  </div>
</template>
