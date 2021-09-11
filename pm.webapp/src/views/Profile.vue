<template>
  <h1 class="h2 py-3">Rellene el Formulario para actualizar sus datos</h1>
  <personalInfo></personalInfo>
  <studiesList></studiesList>
  <button class="btn btn-primary">
    <svg width="19" height="18" fill="currentColor">
      <use xlink:href="#plus-square" />
    </svg> Agregar
  </button>
  <studiesForm></studiesForm>
  <pollForm></pollForm>
</template>
<script>
import studiesForm from '@/components/StudiesForm.vue'
import studiesList from '@/components/StudiesList.vue'
import personalInfo from '@/components/PersonalInfo.vue'
import pollForm from '@/components/PollForm.vue'

export default {
  name: 'Profile',
  components: {
    studiesForm,
    studiesList,
    personalInfo,
    pollForm
  }
}
</script>
