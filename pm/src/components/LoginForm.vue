<script setup>
import { ref, reactive } from 'vue'
import { useRouter } from 'vue-router'
import { post } from '@/lib/fetch.js'
import { useVuelidate } from '@vuelidate/core'
import { required, email } from '@vuelidate/validators'

const router = useRouter()

const isLogged = ref(false)
const message = ref("")
const userEmail = ref("")

const user = reactive({
  firstName: "",
  lastName: ""
})

const rules = {
  userEmail: { required, email } 
}

const v = useVuelidate(
  rules,
  { userEmail },
  { $autoDirty: true }
)

const logout = () => {
  isLogged.value = false   
  localStorage.removeItem("user");
}

const login = async () => {
  const data = {
    username: userEmail.value,
    password: Date.now().toString()
  }

  console.log(v)

  const isValid = await v.value.$validate()

  if(!isValid) {
    message.value = v.value.$errors[0].$message
    return
  }

  post('/accounts/authenticate', data)
    .then(res => {
      if(res.data.token) {
        localStorage.setItem("user", JSON.stringify(res.data))

        user.firstName = res.data.firstName
        user.lastName = res.data.lastName

        isLogged.value = true
        userEmail.value = ""

        router.push({ name: "profile" })
      }
    })
    .catch(err => {
      if(err.response.status === 401) logount()
      if(err.message) message.value = err.message
    })
}

new Promise(() => {
  const userJson = localStorage.getItem("user") 

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
        <button type="button" @click="login" class="btn btn-primary mb-3">
          <svg class="me-2" width="18" height="18" fill="currentColor">
            <use xlink:href="#check-square" />
          </svg>
          Ingresar
        </button>
    </div>
    <div v-else>
      <p class="h3 my-3">Hola {{ user.firstName + " " + user.lastName }}</p>
      <button type="button" @click="logout" class="btn btn-primary mb-3">
        <svg class="me-2" width="18" height="18" fill="currentColor">
          <use xlink:href="#check-square" />
        </svg>
        Salir
      </button>
    </div>
  </div>
</template>
