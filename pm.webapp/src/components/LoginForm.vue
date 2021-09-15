<template>
  <div v-if="!isLogged" class="login">
    <div
      v-if="message"
      class="alert alert-danger alert-dismissible fade show"
      role="alert"
    >
      {{ message }}
      <button
        @click="message = undefined"
        type="button"
        class="btn-close"
        data-bs-dismiss="alert"
        aria-label="Close"
      ></button>
    </div>
    <div class="form-floating mb-3">
      <input
          v-model="v$.form.email.$model"
          class="form-control"
          :class="{ 'is-invalid': v$.form.email.$error }"
          id="email"
          type="mail"
          placeholder="your@email.com"
      />
      <label for="email">Correo Eléctronico</label>
    </div>
    <button type="button" @click="login" class="btn btn-primary mb-3">
      <svg class="me-2" width="18" height="18" fill="currentColor">
        <use xlink:href="#check-square" />
      </svg> Ingresar
    </button>
  </div>
  <button v-else type="button" @click="logout" class="btn btn-primary mb-3">
    <svg class="me-2" width="18" height="18" fill="currentColor">
      <use xlink:href="#check-square" />
    </svg> Salir
  </button>
</template>
<script>
import debounce from "lodash/debounce";
import useVuelidate from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'


export default {
  name: "LoginForm",
  setup() {
    return { v$: useVuelidate() }
  },
  data() {
    return {
      message: undefined,
      isLogged: false,
      form: {
        email: ""
      }
    }
  },
  beforeMount() {
    const loggedIn = localStorage.getItem("user");
    this.isLogged = !!loggedIn;
  },
  validations() {
    return {
      form: {
        email: {required, email}
      }
    }
  },
  methods: {
    login: debounce(
      async function () {
        this.message = "";

        const isOk = this.v$.$validate();

        if (!isOk)
          return this.message = "Email incorrecto.";

        let data = {
          username: this.form.email,
          password: Date.now().toString()
        };

        const init = {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(data)
        };

        const uri = process.env.VUE_APP_PM_API + "Accounts/Authenticate";

        const response = await fetch(uri, init)

        if (!response.ok) {
          if(response.status == 400)
            data = await response.json();
          else if(response.status == 401)
            this.logout();
          else
            this.message = "Se ha presentado un inconveniente por favor vuelva intentar en un minuto";
        }
        else {
          data = await response.json();
        }
        
        if (data.message)
          this.message = data.message;
        else {
          if (data.token) {
            localStorage.setItem("user", JSON.stringify(data))
            this.$router.push({ name: 'Profile' });
          }
        }
      },
      250
    ),
    logout() {
      localStorage.removeItem("user");
      this.isLogged = false;
    }
  }
}
</script>
<style></style>
