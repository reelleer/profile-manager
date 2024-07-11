<script setup>
import { ref } from 'vue'
import PersonalInfo from '../components/PersonalInfo.vue'
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
  })
  .catch(err => {
    alert(err.message || "Error con el servidor, no se pudo cargar el perfil")
  })

const onInfoSave = info => {
  profile.value.personalInfo = info
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
