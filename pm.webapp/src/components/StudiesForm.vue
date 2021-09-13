<template>
  <div class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <select v-model="form.type" class="form-select" id="floatingSelect" aria-label="Tipo de Estudio">
          <option selected>Open this select menu</option>
          <option value="1">Liciatura/Ingenieria</option>
          <option value="2">Postrgrado/Epecialización</option>
          <option value="3">Maestría</option>
          <option value="3">Doctorado</option>
        </select>
        <label for="floatingInput">Tipo de Estudio</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.country" class="form-control" id="country-study" type="text" placeholder="Nicaragua">
        <label for="country-study">Pais de Estudio</label>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input v-model="form.university" class="form-control" type="text" placeholder="Universiad">
        <label for="for">Universiad</label>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input v-model="form.study" class="form-control" type="text" placeholder="Carrera">
        <label for="for">Carrera</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.begin" class="form-control" type="date" placeholder="Fecha de Inicio">
        <label for="for">Fecha de Inicio</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.end" class="form-control" type="date" placeholder="Fecha de Finalización">
        <label for="for">Fecha de Finalización</label>
      </div>
    </div>
    <div class="col-auto">
      <button type="button" @click="$emit('sform:cancelar')" class="btn btn-secondary mb-3">
        <svg class="me-2" width="18" height="18" fill="currentColor">
          <use xlink:href="#check-square" />
        </svg> Cancelar
      </button>
      <button type="button" @click="save" class="btn btn-primary mb-3">
        <svg class="me-2" width="18" height="18" fill="currentColor">
          <use xlink:href="#check-square" />
        </svg> Guardar
      </button>
    </div>
  </div>
</template>
<script>
const formatDate =
  value => (new Date(Date.parse(value))).toISOString().slice(0,10);

export default {
  name: 'StudiesForm',
  props: {
    type: { type: Number, default: 0 },
    country: {type: String, default: "" },
    university: {type: String, default: ""},
    study: { type: String, default: "" },
    begin: { type: Date, default: () => new Date(Date.now()) },
    end: { type: Date, default: () => new Date(Date.now()) }
  },
  data () {
    return {
      form: {
        type: this.type,
        country: this.country,
        university: this.university,
        study: this.study,
        begin: formatDate(this.begin),
        end: formatDate(this.end)
      }
    }
  },
  methods: {
    save(){
      this.$emit(
        "sform:save",
        {
          ...this.form,
          begin: new Date(this.form.begin),
          end: new Date(this.form.end)
        }
      )
    }
  }
}
</script>
<style></style>
