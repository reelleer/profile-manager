<template>
  <h2 class="h2 border-bottom border-dark py-2">Historial Académico</h2>
  <div v-if="show" class="row row-cols-1 row-cols-xl-2 g-3 mb-3 mb-3">
    <div v-for="study in items" :key="study.id" class="col">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">{{ study.study }}</h5>
          <h6 class="card-subtitle text-muted">{{ study.university }}</h6>
          <p class="fw-light">
            {{ study.country }}, {{ formatDate(study.begin) }} -
            {{ formatDate(study.end) }}
          </p>
          <div class="d-flex justify-content-end">
            <svg
              @click="$emit('slist:edit', study.id)"
              class="text-primary me-2"
              fill="currentColor"
              height="18"
              role="button"
              width="18"
            >
              <use xlink:href="#pencil" />
            </svg>
            <svg
              @click="$emit('slist:remove', study.id)"
              class="text-danger"
              fill="currentColor"
              height="18"
              role="button"
              width="18"
            >
              <use xlink:href="#trash" />
            </svg>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
let formatDate = (str) => {
  let date = new Date(Date.parse(str));
  return `${date.getMonth() + 1}/${date.getFullYear()}`;
};
export default {
  name: "StudiesList",
  emits: ["slist:edit", "slist:remove"],
  props: {
    show: { type: Boolean, default: true },
    items: { type: Array, default: () => [] },
  },
  methods: {
    formatDate,
  },
};
</script>
<style></style>
