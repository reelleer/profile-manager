<template>
  <h2 class="h3 border-bottom border-dark py-2">
    Ingrese sus datos Personales
  </h2>
  <div @input="save" class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.name.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.name.$error }"
          id="name"
          placeholder="Pedro"
        />
        <label for="name">Nombres</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.lastName.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.lastName.$error }"
          id="lastName"
          placeholder="Páramo"
        />
        <label for="lastName">Apellidos</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.birthDate.$model"
          type="date"
          class="form-control"
          :class="{ 'is-invalid': v$.form.birthDate.$error }"
          id="birthDate"
          placeholder="-"
        />
        <label for="birthDate">Fecha Nacimiento</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.birthPlace.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.birthPlace.$error }"
          id="birthPlace"
          placeholder="Nicaragua"
        />
        <label for="birthPlace">Lugar de Nacimiento</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.country.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.country.$error }"
          id="country"
          placeholder="Nicaragua"
        />
        <label for="country">País de Residencia</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.address.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.address.$error }"
          id="address"
          placeholder="Dirección domiciliar"
        />
        <label for="address">Dirección Domiciliar</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.phone.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.phone.$error }"
          id="floatingInput"
          placeholder="00000000"
        />
        <label for="phone">Teléfono<span>/</span>Celular</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.email.$model"
          type="email"
          class="form-control"
          :class="{ 'is-invalid': v$.form.email.$error }"
          id="email"
          placeholder="name@example.com"
        />
        <label for="email">Correo Electrónico</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <select
          v-model="v$.form.working.$model"
          class="form-select"
          :class="{ 'is-invalid': v$.form.working.$error }"
          id="working"
          aria-label="Situación Laboral"
        >
          <option selected>(Seleccione un valor)</option>
          <option value="1">Negocio propio</option>
          <option value="2">Con Empleo</option>
          <option value="3">Sin Empleo</option>
        </select>
        <label for="working">Situación Laboral</label>
      </div>
    </div>
  </div>
  <h2 class="h3 border-bottom border-dark pb-2">Redes Sociales</h2>
  <div class="row row-cols-1 row-cols-md-2 row-cols-xl-4">
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.twitter.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.twitter.$error }"
          id="twitter"
          placeholder="twitter"
        />
        <label for="twitter">Twitter</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.facebook.$model"
          type="text"
          class="form-control"
          id="facebook"
          placeholder="Facebook"
        />
        <label for="facebook">Facebook</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.linkedin.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.linkedin.$error }"
          id="linkedin"
          placeholder="LinkedIn"
        />
        <label for="linkedin">LinkedIn</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
          v-model="v$.form.instagram.$model"
          type="text"
          class="form-control"
          :class="{ 'is-invalid': v$.form.instagram.$error }"
          id="instagram"
          placeholder="Instagram"
        />
        <label for="instagram">Instagram</label>
      </div>
    </div>
  </div>
</template>
<script>
import debounce from "lodash/debounce";
import useVuelidate from "@vuelidate/core";
import { required, email, maxLength, numeric } from "@vuelidate/validators";

export default {
  name: "PersonalInfo",
  setup() {
    return { v$: useVuelidate() };
  },
  props: {
    name: { type: String, default: "" },
    lastName: { type: String, default: "" },
    birthDate: { type: Date, default: "" },
    birthPlace: { type: String, default: "" },
    country: { type: String, default: "" },
    address: { type: String, default: "" },
    phone: { type: String, default: "" },
    email: { type: String, default: "" },
    twitter: { type: String, default: "" },
    facebook: { type: String, default: "" },
    linkedin: { type: String, default: "" },
    instagram: { type: String, default: "" },
    working: { type: String, default: "" },
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
        working: this.working,
      },
    };
  },
  validations() {
    return {
      form: {
        name: { required, maxLength: maxLength(50) },
        lastName: { required, maxLength: maxLength(50) },
        birthDate: { required },
        birthPlace: { required, maxLength: maxLength(150) },
        country: { required, maxLength: maxLength(150) },
        address: { required, maxLength: maxLength(150) },
        phone: { required, maxLength: maxLength(100) },
        email: { required, email, maxLength: maxLength(128) },
        twitter: { maxLength: maxLength(128) },
        facebook: { maxLength: maxLength(128) },
        linkedin: { maxLength: maxLength(128) },
        instagram: { maxLength: maxLength(128) },
        working: { required, numeric },
      },
    };
  },
  methods: {
    save: debounce(function () {
      this.$emit("pinfo:save", { ...this.form });
    }, 500),
  },
};
</script>
<style></style>
