<template>
  <div class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <select class="form-select" id="floatingSelect" aria-label="Tipo de Estudio">
          <option selected>Open this select menu</option>
          <option value="1">Liciatura/Ingenieria</option>
          <option value="2">Postrgrado/Epecialización</option>
          <option value="3">Maestría</option>
          <option value="3">Doctorado</option>
        </select>
        <label for="floatingInput">Tipo de Estudio</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input class="form-control" id="country-study" type="text" placeholder="Nicaragua">
        <label for="country-study">Pais de Estudio</label>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input class="form-control" type="text" placeholder="Universiad">
        <label for="for">Universiad</label>
      </div>
    </div>
    <div class="col-md-12">
      <div class="form-floating mb-3">
        <input class="form-control" type="text" placeholder="Carrera">
        <label for="for">Carrera</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input class="form-control" type="date" placeholder="Fecha de Inicio">
        <label for="for">Fecha de Inicio</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input class="form-control" type="date" placeholder="Fecha de Finalización">
        <label for="for">Fecha de Finalización</label>
      </div>
    </div>
    <div class="col-auto">
      <button type="button" class="btn btn-primary mb-3">
        <svg class="me-2" width="18" height="18" fill="currentColor">
          <use xlink:href="#check-square" />
        </svg> Guardar
      </button>
    </div>
  </div>
</template>
<script>
export default {
  name: 'StudiesForm'
}
</script>
<style></style>
