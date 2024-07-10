<script setup>
import { ref } from 'vue'
import PersonalInfo from '../components/PersonalInfo.vue'

const ready = ref(true)
</script>
<template>
  <p v-if="!ready">Estamos cargando tu perfil.</p>
  <div v-else>
    <h1 class="h2 py-3">Rellene el Formulario para actualizar sus datos</h1>
    <PersonalInfo></PersonalInfo>
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
