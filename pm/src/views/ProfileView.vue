<script setup>
import { ref } from 'vue'
import { get, setUrl } from '../lib/fetch.js'
import PersonalInfo from '../components/PersonalInfo.vue'

const url = setUrl('/profiles')

const ready = ref(false)
const sending = ref(false)

const profile = ref({})

const getProfile = () => {
    const userJson = localStorage.getItem("user");

    if (userJson) {
      const user = JSON.parse(userJson);
      console.log(user, userJson)

      get(url(user.id)) 
        .then( res => {
          profile.value = res.data
          ready.value = true
          console.log(res)
        })
    }
} 

getProfile()
</script>
<template>
  <p v-if="!ready">Estamos cargando tu perfil.</p>
  <div v-else>
    <h1 class="h2 py-3">Rellene el Formulario para actualizar sus datos</h1>
    <PersonalInfo :info="profile.personalInfo"></PersonalInfo>
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
