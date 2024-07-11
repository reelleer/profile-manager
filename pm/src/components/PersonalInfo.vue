<script setup>
import { ref } from 'vue'
import { formatDate } from '../lib/helpers.js'
import { useVuelidate } from '@vuelidate/core'
import { required, email, maxLength, numeric } from '@vuelidate/validators'

const props = defineProps({
  info: {
    type: Object,
    default: {}
  }
})

const emit = defineEmits(['infoSave'])

const firstName = ref(props.info.firstName)
const lastName = ref(props.info.lastName)
const birthDate = ref(
  props.info.birthDate
  ? formatDate(props.info.birthDate)
  : ''
)
const birthPlace = ref(props.info.birthPlace)
const country = ref(props.info.country)
const address = ref(props.info.address)
const phone = ref(props.info.phone)
const userEmail = ref(props.info.email)
const working = ref(props.info.working)
const twitter = ref(props.info.twitter)
const facebook = ref(props.info.facebook)
const linkedin = ref(props.info.linkedin)
const instagram = ref(props.info.instagram)

const rules = {
  firstName: { required, maxLength: maxLength(50) },
  lastName: { required, maxLength: maxLength(50) },
  birthDate: [ required ], 
  birthPlace: { required, maxLength: maxLength(150) }, 
  country: { required, maxLength: maxLength(150) }, 
  address: { required, maxLength: maxLength(150) }, 
  phone: { required, maxLength: maxLength(150) }, 
  userEmail: { required, email, maxLength: maxLength(128) }, 
  working: [required, numeric], 
  twitter: { maxLength: maxLength(128) }, 
  facebook: { maxLength: maxLength(128) }, 
  linkedin: { maxLength: maxLength(128) }, 
  instagram: { maxLength: maxLength(128) } 
}

const v = useVuelidate(
  rules,
  {
    firstName,
    lastName,
    birthDate,
    birthPlace,
    country,
    address,
    phone,
    userEmail,
    working,
    twitter,
    facebook,
    linkedin,
    instagram
  },
  { $autoDirty: true }
)

const emitSave = () => {
  const data = {
    firstName: firstName.value,
    lastName: lastName.value,
    birthDate: birthDate.value,
    birthPlace: birthPlace.value,
    country: country.value,
    address: address.value,
    phone: phone.value,
    userEmail: userEmail.value,
    working: working.value,
    twitter: twitter.value,
    facebook: facebook.value,
    linkedin: linkedin.value,
    instagram: instagram.value
  }

  emit('infoSave', data)
}

let timeoutId

const onInput = () => {
  if(timeoutId) clearTimeout(timeoutId)

  timeoutId = setTimeout(emitSave, 700)
}
</script>
<template>
  <h2 class="h3 border-bottom border-dark py-2">
    Ingrese sus datos Personales
  </h2>
  <div @input="onInput" class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="firstName"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.firstName.$error }"
        id="name"
        placeholder="Pedro"
        />
        <label for="name">Nombres</label>
        <div class="invalid-feedback">
          {{v.firstName.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="lastName"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.lastName.$error }"
        id="lastName"
        placeholder="Páramo"
        />
        <label for="lastName">Apellidos</label>
        <div class="invalid-feedback">
          {{v.lastName.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="birthDate"
        type="date"
        class="form-control"
        :class="{ 'is-invalid': v.birthDate.$error }"
        id="birthDate"
        />
        <label for="birthDate">Fecha Nacimiento</label>
        <div class="invalid-feedback">
          {{v.birthDate.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="birthPlace"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.birthPlace.$error }"
        id="birthPlace"
        placeholder="Managua"
        />
        <label for="birthPlace">Lugar de Nacimiento</label>
        <div class="invalid-feedback">
          {{v.birthPlace.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="country"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.country.$error }"
        id="country"
        placeholder="Nicaragua"
        />
        <label for="country">País de Residencia</label>
          {{v.country.$errors[0]?.$message }}
        <div class="invalid-feedback">
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="address"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.address.$error }"
        id="address"
        placeholder="Dirección domiciliar"
        />
        <label for="address">Dirección Domiciliar</label>
        <div class="invalid-feedback">
          {{v.address.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="phone"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.phone.$error }"
        id="floatingInput"
        placeholder="00000000"
        />
        <label for="phone">Teléfono<span>/</span>Celular</label>
        <div class="invalid-feedback">
          {{v.phone.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="userEmail"
        type="email"
        class="form-control"
        :class="{ 'is-invalid': v.userEmail.$error }"
        id="email"
        placeholder="name@example.com"
        />
        <label for="email">Correo Electrónico</label>
        <div class="invalid-feedback">
          {{v.userEmail.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <select
          v-model="working"
          class="form-select"
          :class="{ 'is-invalid': v.working.$error }"
          id="working"
          aria-label="Situación Laboral"
          >
          <option value="" selected>(Seleccione un valor)</option>
          <option value="1">Negocio propio</option>
          <option value="2">Con Empleo</option>
          <option value="3">Sin Empleo</option>
        </select>
        <label for="working">Situación Laboral</label>
        <div class="invalid-feedback">
          {{v.working.$errors[0]?.$message }}
        </div>
      </div>
    </div>
  </div>
  <h2 class="h3 border-bottom border-dark pb-2">Redes Sociales</h2>
  <div class="row row-cols-1 row-cols-md-2 row-cols-xl-4">
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="twitter"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.twitter.$error }"
        id="twitter"
        placeholder="twitter"
        />
        <label for="twitter">Twitter</label>
        <div class="invalid-feedback">
          {{v.twitter.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="facebook"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.facebook.$error }"
        id="facebook"
        placeholder="Facebook"
        />
        <label for="facebook">Facebook</label>
        <div class="invalid-feedback">
          {{v.facebook.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="linkedin"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.linkedin.$error }"
        id="linkedin"
        placeholder="LinkedIn"
        />
        <label for="linkedin">LinkedIn</label>
        <div class="invalid-feedback">
          {{v.linkedin.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="instagram"
        type="text"
        class="form-control"
        :class="{ 'is-invalid': v.instagram.$error }"
        id="instagram"
        placeholder="Instagram"
        />
        <label for="instagram">Instagram</label>
        <div class="invalid-feedback">
          {{v.instagram.$errors[0]?.$message }}
        </div>
      </div>
    </div>
  </div>
</template>
