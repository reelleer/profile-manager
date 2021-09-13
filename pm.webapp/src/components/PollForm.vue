<template>
  <h2 class="h2 border-bottom border-dark py-2">Club Erasmus</h2>
  <div @input="save" class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <textarea v-model="form.opportunities" class="form-control mb-3" id="opportunities" placeholder="¿Qué oportunidades le ha brindado el programa Erasmus?"></textarea>
    </div>
    <div class="col">
      <textarea v-model="form.activities" class="form-control mb-3" id="floatingInput" placeholder="¿Qué actividades te gustaría que el Club Erasmus promovido por la Unión Europea en Nicaragua impulsara?"></textarea>
    </div>
    <div class="col">
      <div class="mb-3">
        <label for="contacts">¿Tienes contacto con estudiantes becados a través del Programa Erasmus? ¿En caso positivo cuántos conoces?</label>
        <input v-model="form.contacts" type="number" id="contacts" min="0" max="30" class="form-control" placeholder="Contactos">
      </div>
    </div>
    <div class="col">
      <div class="form-check form-switch mb-3">
        <input v-model="form.follower" class="form-check-input" type="checkbox" id="follower">
        <label for="follower">¿Sigues las redes sociales de la DUE?</label>
      </div>
    </div>
  </div>
</template>
<script>
import debounce from 'lodash/debounce'

export default {
  name: 'PollForm',
  props: {
    opportunities: { type: String, default: '' },
    activities: { type: String, default: '' },
    contacts: { type: Number, default: 0 },
    follower: { type: Boolean, default: false }
  },
  data() {
    return {
      form: {
        opportunities: this.opportunities,
        activities: this.activities,
        contacts: this.contacts,
        follower: this.follower
      }
    }
  },
  methods: {
    save: debounce(function () {
        this.$emit("poll:save", { ...this.form })
      },
      1800
    )
  }
}
</script>
<style></style>
