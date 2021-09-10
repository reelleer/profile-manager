<template>
  <h2 class="h2 border-bottom border-dark py-2">Historial Académico</h2>
  <div class="row row-cols-1 row-cols-xl-2 g-3 mb-3 mb-3">
    <div class="col">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">Ingeniería en Sistemas de Información</h5>
          <h6 class="card-subtitle text-muted">Universidad Católica Redemptoris Mater</h6>
          <p class="fw-light">Nicaragua, MM/YYYY - MM/YYYY</p>
          <div class="d-flex justify-content-end">
            <svg class="text-primary me-2" width="18" height="18" fill="currentColor">
              <use xlink:href="#pencil" />
            </svg>
            <svg class="text-danger" width="18" height="18" fill="currentColor">
              <use xlink:href="#trash" />
            </svg>
          </div>
        </div>
      </div>
    </div>
    <div class="col">
      <div class="card">
        <div class="card-body">
          <h5 class="card-title">Ingeniería en Sistemas de Información</h5>
          <h6 class="card-subtitle text-muted">Universidad Católica Redemptoris Mater</h6>
          <p class="fw-light">Nicaragua, MM/YYYY - MM/YYYY</p>
          <div class="d-flex justify-content-end">
            <svg class="text-primary me-2" width="18" height="18" fill="currentColor">
              <use xlink:href="#pencil" />
            </svg>
            <svg class="text-danger" width="18" height="18" fill="currentColor">
              <use xlink:href="#trash" />
            </svg>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: 'StudiesList',
}
</script>
<style></style>
