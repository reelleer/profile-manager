<template>
  <div class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <select
            v-model="v$.form.type.$model"
            class="form-select"
            :class="{ 'is-invalid': v$.form.type.$error }"
            id="type"
            aria-label="Tipo de Estudio"
        >
          <option selected value="">(Seleccione una opcción)</option>
          <option value="1">Licenciatura/Ingeniería</option>
          <option value="2">Postgrado/Especialización</option>
          <option value="3">Maestría</option>
          <option value="3">Doctorado</option>
        </select>
        <label for="type">Tipo de Estudio</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
            v-model="v$.form.country.$model"
            class="form-control"
            :class="{ 'is-invalid': v$.form.country.$error }"
            id="country-study"
            type="text"
            placeholder="Nicaragua"
        />
        <label for="country-study">Pais de Estudio</label>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input
        v-model="v$.form.university.$model"
        class="form-control"
          :class="{ 'is-invalid': v$.form.university.$error }"
        type="text"
        placeholder="Universidad"
        />
        <label for="university">Universiad</label>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input
        v-model="v$.form.study.$model"
        class="form-control"
        :class="{ 'is-invalid': v$.form.study.$error }"
        type="text"
        placeholder="Carrera/Studio"
        />
        <label for="study">Carrera/Studio</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="v$.form.begin.$model"
        class="form-control"
        :class="{ 'is-invalid': v$.form.begin.$error }"
        type="date"
        placeholder="Fecha de Inicio"
        />
        <label for="begin">Fecha de Inicio</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="v$.form.end.$model"
        class="form-control"
        :class="{ 'is-invalid': v$.form.end.$error }"
        type="date"
        placeholder="Fecha de Finalización"
        />
        <label for="end">Fecha de Finalización</label>
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
import useVuelidate from '@vuelidate/core'
import { required, maxLength, numeric, minValue } from '@vuelidate/validators'

const formatDate =
  value => (new Date(Date.parse(value))).toISOString().slice(0,10);

export default {
  name: 'StudiesForm',
  setup() {
    return { v$: useVuelidate() }
  },
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
  validations() {
    return {
      form: {
        type: { required, numeric, minValue: minValue(1) },
        country: { required, maxLength: maxLength(150) },
        university: {required, maxLength: maxLength(150) },
        study: { required, maxLength: maxLength(150) },
        begin: { required },
        end: { required }
      }
    }
  },
  methods: {
    async save(){
      const isOk = await this.v$.$validate()
      if (isOk) {
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
}
</script>
<style></style>
