<template>
  <h2 class="h2 border-bottom border-dark py-2">Club Erasmus</h2>
  <div class="row row-cols-1 row-cols-md-2">
    <div class="col">
      <textarea class="form-control mb-3" id="opportunities" placeholder="¿Qué oportunidades le ha brindado el programa Erasmus?"></textarea>
    </div>
    <div class="col">
      <textarea class="form-control mb-3" id="floatingInput" placeholder="¿Qué actividades te gustaría que el Club Erasmus promovido por la Unión Europea en Nicaragua impulsara?"></textarea>
    </div>
    <div class="col">
      <div class="mb-3">
        <label for="contacts">¿Tienes contacto con estudiantes becados a través del Programa Erasmus? ¿En caso positivo cuántos conoces?</label>
        <input type="number" id="contacts" min="0" max="30" class="form-control" placeholder="Contactos">
      </div>
    </div>
    <div class="col">
      <div class="form-check form-switch mb-3">
        <input class="form-check-input" type="checkbox" id="fallower">
        <label for="fallower">¿Sigues las redes sociales de la DUE?</label>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  name: 'PollForm'
}
</script>
<style></style>
