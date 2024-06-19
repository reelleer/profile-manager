<script setup>
import { formatDate } from '../lib/helpers.js'

const emit = defineEmits(['studyEdit', 'studyRemove'])

const props = defineProps({
  items: {
    type: Array,
    default: []
  }
})

const onEdit = (id) => emit('studyEdit', id)
const onRemove = (id) => emit('studyRemove', id)
</script>
<template>
  <div class="row row-cols-1 row-cols-xl-2 g-3 mb-3 mb-3">
    <div v-for="study in props.items" :key="study.id" class="col">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">{{ study.study }}</h5>
          <h6 class="card-subtitle text-muted">{{ study.university }}</h6>
          <p class="fw-light">
          {{ study.country }}, {{ formatDate(study.begin) }} -
          {{ formatDate(study.end) }}
          </p>
          <div class="d-flex justify-content-end">
            <AppIcon 
              icon-name="pencil"
              class="text-primary me-2"
              @click="onEdit(study.id)"
              role="button"
            />
            <AppIcon
              icon-name="trash"
              class="text-danger"
              @click="onRemove(study.id)"
              role="button"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
