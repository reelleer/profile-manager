<template>
  <form v-if="!isLogged" @submit.prevent="login" class="login">
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
          v-model="form.email"
          class="form-control"
          id="email"
          type="mail"
          placeholder="your@email.com"
          required
      />
      <label for="email">Correo Eléctronico</label>
    </div>
    <button type="submit" class="btn btn-primary mb-3">
      <svg class="me-2" width="18" height="18" fill="currentColor">
        <use xlink:href="#check-square" />
      </svg> Ingresar
    </button>
  </form>
  <button v-else type="button" @click="logout" class="btn btn-primary mb-3">
    <svg class="me-2" width="18" height="18" fill="currentColor">
      <use xlink:href="#check-square" />
    </svg> Salir
  </button>
</template>
<script>
import debounce from "lodash/debounce";
const loggedIn = localStorage.getItem("user");

export default {
  name: "LoginForm",
  data() {
    return {
      message: undefined,
      isLogged: !!loggedIn,
      form: {
        email: ""
      }
    }
  },
  methods: {
    login: debounce(
      async function () {
        this.message = "";
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
      }
    )
  },
  logout() {
    localStorage.removeItem("user");
    this.isLogged = false;
  }
}
</script>
<style></style>
