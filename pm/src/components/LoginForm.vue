<script setup>
import { ref, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'
import { post } from '@/lib/fetch.js'
import { useSession } from '../composables/session.js'

const { isLogged, fullName, login, logout } = useSession()

const router = useRouter()

const message = ref('')
const userEmail = ref('')

const user = reactive({
  firstName: '',
  lastName: ''
})

const rules = {
  userEmail: { required, email } 
}

const v = useVuelidate(
  rules,
  { userEmail },
  { $autoDirty: true }
)

const onLogout = () => logout() 

const onLogin = async () => {
  const isValid = await v.value.$validate()

  if(!isValid) {
    message.value = v.value.$errors[0].$message
    return
  }

  const data = {
    username: userEmail.value,
    password: Date.now().toString()
  }

  post('/accounts/authenticate', data)
    .then(res => {
      if(res.data.token) {
        login(res.data)

        userEmail.value = ''

        router.push({ name: 'profile' })
      }
    })
    .catch(err => {
      if(err.message) message.value = err.message
    })
}

new Promise(() => {
  const userJson = localStorage.getItem('user') 

  if(userJson) {
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
      <div
        v-if="message"
        class="alert alert-danger alert-dismissible fade show"
        role="alert"
        >
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
        </div>
        <button type="button" @click="onLogin" class="btn btn-primary mb-3">
          <AppIcon class="me-2" icon-name="check-square" />
          Ingresar
        </button>
    </div>
    <div v-else>
      <p class="h3 my-3">Hola {{ fullName }}</p>
      <button type="button" @click="onLogout" class="btn btn-primary mb-3">
        <AppIcon class="me-2" icon-name="check-square" />
        Salir
      </button>
    </div>
  </div>
</template>
