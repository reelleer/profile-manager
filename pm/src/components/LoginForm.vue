<script setup>
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, email, maxLength } from '@vuelidate/validators'
import { post } from '../lib/fetch.js'
import { useSession } from '../composables/session.js'

const { isLogged, login, logout, fullName } = useSession()

const message = ref('')
const userEmail = ref('')

const router = useRouter()

const rules = {
  userEmail: { required, email, maxLength: maxLength(128) }
}

const v = useVuelidate(rules, { userEmail }, { $autoDirty: true })

const onLogin = async () => {
  const isValid = await v.value.$validate()

  if (!isValid) {
    message.value = 'Invalido'
    return
  }

  const data = {
    username: userEmail.value,
    password: Date.now().toString()
  }

  post('/accounts/authenticate', data)
    .then((res) => {
      console.log(res)
      if (!res.data.token) {
        message.value = 'No se pudo autenticar'
        return
      }

      login(res.data)

      userEmail.value = ''

      router.push({ name: 'profile' })
    })
    .catch((err) => {
      console.log(err)
      if (err.response.status === 401) logout()
      if (err.message) message.value = err.message
    })
}
</script>
<template>
  <div class="login">
    <div v-if="!isLogged">
      <div v-if="message" class="alert alert-danger alert-dismissible fade show" role="alert">
        {{ message }}
        <button
          @click="message = ''"
          type="button"
          class="btn-close"
          data-bs-dismiss="alert"
          aria-label="Close"
        ></button>
      </div>
      <div class="form-floating mb-3">
        <input
          v-model="userEmail"
          class="form-control"
          :class="{ 'is-invalid': v.userEmail.$error }"
          id="email"
          type="mail"
          placeholder="your@email.com"
        />
        <label for="email">Correo Eléctronico</label>
        <div class="invalid-feedback">
          {{ v.userEmail.$errors[0]?.$message }}
        </div>
      </div>
      <button type="button" @click="onLogin" class="btn btn-primary mb-3">
        <svg class="me-2" width="18" height="18" fill="currentColor">
          <use xlink:href="#check-square" />
        </svg>
        Ingresar
      </button>
    </div>
    <div v-else>
      <p class="h3 my-3">Hola {{ fullName }}</p>
      <button type="button" @click="logout" class="btn btn-primary mb-3">
        <svg class="me-2" width="18" height="18" fill="currentColor">
          <use xlink:href="#check-square" />
        </svg>
        Salir
      </button>
    </div>
  </div>
</template>
