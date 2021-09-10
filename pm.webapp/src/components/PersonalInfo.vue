<template>
  <h2 class="h3 border-bottom border-dark py-2">Ingrese sus datos Personales</h2>
  <div class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Pedro">
        <label for="floatingInput">Nombres</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Páramo">
        <label for="floatingInput">Apellidos</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="date" class="form-control" id="floatingInput" placeholder="-">
        <label for="floatingInput">Fecha Nacimiento</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Nicaragua">
        <label for="floatingInput">Lugar de Nacimiento</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Nicaragua">
        <label for="floatingInput">País de Residencia</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Dirección domiciliar">
        <label for="floatingInput">Dirección Domiciliar</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="00000000">
        <label for="floatingInput">Teléfono<span>/</span>Celular</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="email" class="form-control" id="floatingInput" placeholder="name@example.com">
        <label for="floatingInput">Correo Eléctronico</label>
      </div>
    </div>
  </div>
  <h2 class="h3 border-bottom border-dark pb-2">Redes Sociales</h2>
  <div class="row row-cols-1 row-cols-md-2 row-cols-xl-4">
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Twitter">
        <label for="floatingInput">Twitter</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Facebook">
        <label for="floatingInput">Facebook</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="LinkedIn">
        <label for="floatingInput">LinkedIn</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Instagram">
        <label for="floatingInput">Instagram</label>
      </div>
    </div>
  </div>
  <h2 class="h2 border-bottom border-dark py-2">Situación Laboral</h2>
  <div class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <div class="form-floating mb-3">
        <select class="form-select" id="floatingSelect" aria-label="Posición Laboral">
          <option selected>Open this select menu</option>
          <option value="1">One</option>
          <option value="2">Two</option>
          <option value="3">Three</option>
        </select>
        <label for="floatingInput">Posición Laboral</label>
      </div>
    </div>
    <div class="col">
      <div class="form-floating mb-3">
        <input type="text" class="form-control" id="floatingInput" placeholder="Facebook">
        <label for="floatingInput">Facebook</label>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: 'PersonalInfo'
}
</script>
<style></style>
