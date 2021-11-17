<template>
  <h2 class="h2 border-bottom border-dark py-2">Club Erasmus</h2>
  <div @input="save" class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <textarea
        v-model="v$.form.opportunities.$model"
        class="form-control mb-3"
        :class="{ 'is-invalid': v$.form.opportunities.$error }"
        id="opportunities"
        placeholder="¿Qué oportunidades le ha brindado el programa Erasmus?"
      ></textarea>
    </div>
    <div class="col">
      <textarea
        v-model="v$.form.activities.$model"
        class="form-control mb-3"
        :class="{ 'is-invalid': v$.form.activities.$error }"
        id="activities"
        placeholder="¿Qué actividades te gustaría que el Club Erasmus promovido por la Unión Europea en Nicaragua impulsara?"
      ></textarea>
    </div>
    <div class="col">
      <div class="mb-3">
        <label for="contacts"
          >¿Tienes contacto con estudiantes becados a través del Programa
          Erasmus? ¿En caso positivo cuántos conoces?</label
        >
        <input
          v-model="form.contacts"
          type="number"
          id="contacts"
          min="0"
          max="30"
          class="form-control"
          placeholder="Contactos"
        />
      </div>
    </div>
    <div class="col">
      <div class="form-check form-switch mb-3">
        <input
          v-model="form.follower"
          class="form-check-input"
          type="checkbox"
          id="follower"
        />
        <label for="follower">¿Sigues las redes sociales de la DUE?</label>
      </div>
    </div>
  </div>
</template>
<script>
import debounce from "lodash/debounce";
import useVuelidate from "@vuelidate/core";
import { required, maxLength } from "@vuelidate/validators";

export default {
  name: "PollForm",
  emits: ["poll:save"],
  setup() {
    return { v$: useVuelidate() };
  },
  props: {
    opportunities: { type: String, default: "" },
    activities: { type: String, default: "" },
    contacts: { type: Number, default: 0 },
    follower: { type: Boolean, default: false },
  },
  data() {
    return {
      form: {
        opportunities: this.opportunities,
        activities: this.activities,
        contacts: this.contacts,
        follower: this.follower,
      },
    };
  },
  validations() {
    return {
      form: {
        opportunities: { required, maxLength: maxLength(1000) },
        activities: { required, maxLength: maxLength(1000) },
        contacts: this.contacts,
        follower: this.follower,
      },
    };
  },
  methods: {
    save: debounce(function () {
      this.$emit("poll:save", { ...this.form });
    }, 1800),
  },
};
</script>
<style></style>
