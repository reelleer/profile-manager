<template>
  <h2 class="h3 border-bottom border-dark py-2">Ingrese sus datos Personales</h2>
  <div @input="save" class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.name" type="text" class="form-control" id="floatingInput" placeholder="Pedro">
        <label for="floatingInput">Nombres</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.lastName" type="text" class="form-control" id="floatingInput" placeholder="Páramo">
        <label for="floatingInput">Apellidos</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.birthDate" type="date" class="form-control" id="floatingInput" placeholder="-">
        <label for="floatingInput">Fecha Nacimiento</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.birthPlace" type="text" class="form-control" id="floatingInput" placeholder="Nicaragua">
        <label for="floatingInput">Lugar de Nacimiento</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.country" type="text" class="form-control" id="floatingInput" placeholder="Nicaragua">
        <label for="floatingInput">País de Residencia</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.address" type="text" class="form-control" id="floatingInput" placeholder="Dirección domiciliar">
        <label for="floatingInput">Dirección Domiciliar</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.phone" type="text" class="form-control" id="floatingInput" placeholder="00000000">
        <label for="floatingInput">Teléfono<span>/</span>Celular</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.email" type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
        <label for="floatingInput">Correo Eléctronico</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <select v-model="form.working" class="form-select" id="floatingSelect" aria-label="Situación Laboral">
          <option selected>(Seleccione un valor)</option>
          <option value="1">Negocio propio</option>
          <option value="2">Con Empleo</option>
          <option value="3">Sin Empleo</option>
        </select>
        <label for="floatingInput">Situación Laboral</label>
      </div>
    </div>
  </div>
  <h2 class="h3 border-bottom border-dark pb-2">Redes Sociales</h2>
  <div class="row row-cols-1 row-cols-md-2 row-cols-xl-4">
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.twitter" type="text" class="form-control" id="floatingInput" placeholder="Twitter">
        <label for="floatingInput">Twitter</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.facebook" type="text" class="form-control" id="floatingInput" placeholder="Facebook">
        <label for="floatingInput">Facebook</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.linkedind" type="text" class="form-control" id="floatingInput" placeholder="LinkedIn">
        <label for="floatingInput">LinkedIn</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input v-model="form.instagram" type="text" class="form-control" id="floatingInput" placeholder="Instagram">
        <label for="floatingInput">Instagram</label>
      </div>
    </div>
  </div>
</template>
<script>
import debounce from 'lodash/debounce';

export default {
  name: 'PersonalInfo',
  props: {
    name: { type: String, default: '' },
    lastName: { type: String, default: '' },
    birthDate: {
      type: Date,
      default: () => { return new Date(Date.now()) }
    },
    birthPlace: { type: String, default: '' },
    country: { type: String, default: '' },
    address: { type: String, default: '' },
    phone: { type: String, default: '' },
    email: { type: String, default: '' },
    twitter: { type: String, default: '' },
    facebook: { type: String, default: '' },
    linkedin: { type: String, default: '' },
    instagram: { type: String, default: '' },
    working: { type: String, default: '' },
  },
  data() {
    return {
      form: {
        name: this.name,
        lastName: this.lastName,
        birthDate: this.birthDate,
        birthPlace: this.birthPlace,
        country: this.country,
        address: this.address,
        phone: this.phone,
        email: this.email,
        twitter: this.twitter,
        facebook: this.facebook,
        linkedin: this.linkedin,
        instagram: this.instagram,
        working: this.working
      }
    }
  },
  methods: {
    save: debounce(function() {
        this.$emit("pinfo:save", { ...this.form })
      },
      500
    )
  }
}
</script>
<style></style>
