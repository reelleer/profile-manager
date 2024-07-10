<script setup>
import { ref, reactive } from 'vue'
import { useVuelidate } from '@vuelidate/core'
import { required, email, maxLength } from '@vuelidate/validators'
import { post } from '../lib/fetch.js'

const isLogged = ref(false)
const message = ref('')
const userEmail = ref('')

const rules = {
  userEmail: { required, email, maxLength: maxLength(128) }
}

const v = useVuelidate(rules, { userEmail }, { $autoDirty: true })

const user = reactive({
  firstName: '',
  lastName: ''
})

const logout = () => {
  isLogged.value = false
  localStorage.removeItem('user')
}

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

      localStorage.setItem('user', JSON.stringify(res.data))

      user.firstName = res.data.firstName
      user.lastName = res.data.lastName

      isLogged.value = true
      userEmail.value = ''
    })
    .catch((err) => {
      console.log(err)
      if (err.response.status === 401) logout()
      if (err.message) message.value = err.message
    })
}

new Promise(() => {
  const userJson = localStorage.getItem('user')

  if (userJson) {
    const userObj = JSON.parse(userJson)

    user.firstName = userObj.firstName
    user.lastName = userObj.lastName

    isLogged.value = true
  }
})
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
      <p class="h3 my-3">Hola {{ user.firstName + ' ' + user.lastName }}</p>
      <button type="button" @click="logout" class="btn btn-primary mb-3">
        <svg class="me-2" width="18" height="18" fill="currentColor">
          <use xlink:href="#check-square" />
        </svg>
        Salir
      </button>
    </div>
  </div>
</template>
