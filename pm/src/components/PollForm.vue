<script setup>
import { ref } from 'vue'
import { useVuelidate } from '@vuelidate/core'
import { required, maxLength } from '@vuelidate/validators'

const props = defineProps({
  opportunities: String,
  activities: String,
  contacts: Number,
  follower: Boolean
})

const emit = defineEmits(['poll-save'])

const opportunities = ref(props.opportunities)
const activities = ref(props.activities)
const contacts = ref(props.contacts)
const follower = ref(props.follower)

const rules = {
  opportunities: { required, maxLength: maxLength(1000) },
  activities: { required, maxLength: maxLength(1000) }
}

const v = useVuelidate(
  rules,
  {
    opportunities,
    activities
  },
  { $autoDirty: true }
)

let timeoutId

const emitUpdate = () => {
  const data = {
    opportunities: opportunities.value,
    activities: activities.value,
    contacts: contacts.value,
    follower: follower.value
  }

  emit('poll-save', data)

  timeoutId = undefined
} 
const onInput = () => {
  if(timeoutId) clearTimeout(timeoutId)

  timeoutId = setTimeout(emitUpdate, 600)
}
</script>
<template>
  <h2 class="h2 border-bottom border-dark py-2">Club Erasmus</h2>
  <div @input="onInput" class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <textarea
        v-model="opportunities"
        class="form-control mb-3"
        :class="{ 'is_invalid': v.opportunities.$error }"
        id="opportunities"
        placeholder="¿Qué oportunidades le ha brindado el programa Erasmus?"
      ></textarea>
      <div class="invalid-feedback">
        {{ v.opportunities.$errors[0]?.$message }}
      </div>
    </div>
    <div class="col">
      <textarea
        v-model="activities"
        class="form-control mb-3"
        :class="{ 'is_invalid': v.activities.$error }"
        id="activities"
        placeholder="¿Qué actividades te gustaría que el Club Erasmus promovido por la Unión Europea en Nicaragua impulsara?"
      ></textarea>
      <div class="invalid-feedback">
        {{ v.activities.$errors[0]?.$message }}
      </div>
    </div>
    <div class="col">
      <div class="mb-3">
        <label for="contacts"
          >¿Tienes contacto con estudiantes becados a través del Programa
          Erasmus? ¿En caso positivo cuántos conoces?</label
        >
        <input
          v-model="contacts"
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
          v-model="follower"
          class="form-check-input"
          type="checkbox"
          id="follower"
        />
        <label for="follower">¿Sigues las redes sociales de la DUE?</label>
      </div>
    </div>
  </div>
</template>
