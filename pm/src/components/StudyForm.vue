<script setup>
import { ref, onMounted } from 'vue'
import { useVuelidate } from '@vuelidate/core' 
import { required, numeric, minValue, maxLength } from '@vuelidate/validators'
import { greaterThan } from '../lib/validators.js'
import { formatDate } from '../lib/helpers.js'
import { getStudyTypes } from '../lib/common.js'

const props = defineProps({
  study: {
    type: Object,
    required: true
  }
})

const emit = defineEmits(['studyCancel', 'studySave'])

const type = ref(props.study.type)
const country = ref(props.study.country)
const university = ref(props.study.university)
const study = ref(props.study.study)
const begin = ref(formatDate(props.study.begin))
const end = ref(formatDate(props.study.end))

const types = ref([])

getStudyTypes().then(res => types.value = res.data)

const rules = {
  type: { required, numeric, minValue: minValue(1) },
  country: { required, maxLength: maxLength(150) },
  university: { required, maxLength: maxLength(150) },
  study: { required, maxLength: maxLength(150) },
  begin: { required },
  end: { required, greaterThan: greaterThan(begin) },
}

const v = useVuelidate(
  rules,
  {
    type,
    country,
    university,
    study,
    begin,
    end
  },
  { $autoDirty: true }
)

const onCancel = () => {
  emit('studyCancel')
}

const onSave = async () => {
  const isValid = await v.value.$validate()

  if(!isValid) return

  const data = {
    type: type.value,
    country: country.value,
    university: university.value,
    study: study.value,
    begin: begin.value,
    end: end.value
  }
  emit('studySave', data)
}

const typeSelect = ref(null)

onMounted(() => {
  //document.getElementById('type').focus()
  typeSelect.value.focus()
})
</script>
<template>
  <div class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <select
          v-model.number="type"
          ref="typeSelect"
          class="form-select"
          :class="{ 'is-invalid': v.type.$error }"
          id="type"
          aria-label="Tipo de Estudio/Participación"
        >
          <option selected value="">(Seleccione una opcción)</option>
          <option v-for="item in types" :key="item.id" :value="item.id">
            {{ item.label }}
          </option>
        </select>
        <label for="type">Tipo de Estudio/Participación</label>
        <div class="invalid-feedback">
          {{ v.type.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="country"
        class="form-control"
        :class="{ 'is-invalid': v.country.$error }"
        id="country-study"
        type="text"
        placeholder="Nicaragua"
        />
        <label for="country-study">País</label>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input
        v-model="university"
        class="form-control"
        :class="{ 'is-invalid': v.university.$error }"
        type="text"
        placeholder="Universidad"
        />
        <label for="university">Universidad</label>
        <div class="invalid-feedback">
          {{ v.university.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input
        v-model="study"
        class="form-control"
        :class="{ 'is-invalid': v.study.$error }"
        type="text"
        placeholder="Carrera/Estudio/Participación"
        />
        <label for="study">Carrera/Estudio/Participación</label>
        <div class="invalid-feedback">
          {{ v.study.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        v-model="begin"
        class="form-control"
        :class="{ 'is-invalid': v.begin.$error }"
        type="date"
        placeholder="Fecha de Inicio"
        />
        <label for="begin">Fecha de Inicio</label>
        <div class="invalid-feedback">
          {{ v.begin.$errors[0]?.$message }}
        </div>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input
        id="end"
        v-model="end"
        class="form-control"
        :class="{ 'is-invalid': v.end.$error }"
        type="date"
        placeholder="Fecha de Finalización"
        />
        <label for="end">Fecha de Finalización</label>
        <div class="invalid-feedback">
          {{ v.end.$errors[0]?.$message }}
        </div>
        <p id="endHelp" class="form-text">
        Si aún no está finalizada, proporcione una fecha aproximada.
        </p>
      </div>
    </div>
    <div class="col-auto">
      <button
        type="button"
        @click="onCancel"
        class="btn btn-secondary mb-3"
        >
        <AppIcon icon-name="check-square" class="me-2" />
        Cancelar
      </button>
      <button type="button" @click="onSave" class="btn btn-primary mb-3">
        <AppIcon icon-name="check-square" class="me-2" />
        Guardar
      </button>
    </div>
  </div>
</template>
