<script setup>
import { ref, computed } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, minLength } from '@vuelidate/validators'
import PersonalInfo from '../components/PersonalInfo.vue'
import StudiesList from '../components/StudiesList.vue'
import StudyForm from '../components/StudyForm.vue'
import PollForm from '../components/PollForm.vue'
import { setUrl, get, put } from '../lib/fetch.js'
import { useSession } from '../composables/session.js'

const ready = ref(false)
const sending = ref(false)

const url = setUrl('/profiles') 

const { userId } = useSession()

const profile = ref({})

const router = useRouter()

const rules = {
  studies: { required, minLength: minLength(1) }
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
  .catch(err => {
    alert(err.message || "Error con el servidor, no se pudo cargar el perfil")
  })

const onInfoSave = info => {
  profile.value.personalInfo = info
}

let studyId
let studyForm

const showForm = ref(false)

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
    studyId = studyForm.id

    showForm.value = true
  }
}

const onStudyRemove = (id) => {
  const index = profile.value.studies.findIndex(s => s.id === id)

  if(index >= 0)
    profile.value.studies.splice(index, 1)
}

const onPollSave = (poll) => {
  profile.value.poll = poll
}

let isSending = false

const profileSave = async () => {
  const isValid = await v.value.$validate()

  if(!isValid) { alert('Lo datos no se pueden guardar, revise los campos con errores')
    return
  }

  isSending = true

  try {
    const data = { ...profile.value }

    data.id = userId.value

    await put(url(userId.value), data)

    router.push({ name: 'ProfileEnd' })
  } catch(error) {
    console.log(error)
    alert(`No se pudo guardar el perfil: ${error.message}`)
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
      @infoSave="onInfoSave"
      :info="profile.personalInfo"
    ></PersonalInfo>
    <h2 class="h3 border-bottom border-dark py-2">Historial Académico</h2>
    <p v-show="showStudiesError" class="my-4 text-danger">
      Debe agregar al menos un etudio realizado con el programa Erasmus
    </p>
    <StudiesList
      v-if="!showForm"
      @studyEdit="onStudyEdit"
      @studyRemove="onStudyRemove"
      :items="profile.studies"
    ></StudiesList>
    <StudyForm
      v-else
      :study="studyForm"
      @studyCancel="onStudyCancel"
      @studySave="onStudySave"
    ></StudyForm>
    <button v-if="!showForm" @click="onStudyNew" class="btn btn-primary">
      <svg width="19" height="18" fill="currentColor">
        <use xlink:href="#plus-square" />
      </svg>
      Agregar
    </button>
    <PollForm
      v-bind="profile.poll"
      @pollSave="onPollSave"
    ></PollForm>
    <div class="d-flex justify-content-center my-4">
      <button @click="profileSave" class="btn btn-primary btn-lg">
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
