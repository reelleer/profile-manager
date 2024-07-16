<script setup>
import { ref } from 'vue'
import PersonalInfo from '../components/PersonalInfo.vue'
import StudiesList from '../components/StudiesList.vue'
import StudyForm from '../components/StudyForm.vue'
import { setUrl, get } from '../lib/fetch.js'

const ready = ref(false)
const sending = ref(false)

const url = setUrl('/profiles') 

const userJson = localStorage.getItem('user')
const userObj = JSON.parse(userJson)

const profile = ref({})

const getProfile = () => get(url(userObj.id))
  .then(res => {
    profile.value = res.data
    ready.value = true

    if(!profile.value.studies || !profile.value.studies.lenght)
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
    <StudiesList v-if="!showForm" :items="profile.studies"></StudiesList>
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
    <div class="d-flex justify-content-center my-4">
      <button class="btn btn-primary btn-lg">
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
