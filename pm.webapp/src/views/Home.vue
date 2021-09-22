<template>
  <div class="home">
    <div class="container">
      <div class="row">
        <div class="col">
          <article>
            <h5 class="post-title post">
              Sean bienvenidos en nombre de la Unión Europea para actualizar sus
              datos.
            </h5>
            <p class="text-justify">
              ABACO DE NICARAGUA está apoyando a la Unión Europea en el proceso
              de actualización de los datos de todos los egresados del Programa
              Erasmus para basado en ello, programar una serie de actividades
              que aglutinen a sus participantes.
            </p>
            <p class="text-justify">
              La protección de su privacidad, incluyendo sus datos personales,
              es de gran importancia para la Unión Europea. Por ello, todos los
              datos que aquí se digiten estarán protegidos por las políticas de
              la Unión Europea y por ende, del procesador de la información,
              quien en este caso será Abaco y deberá guardar la confidencialidad
              debida establecida bajo contrato.
            </p>
            <p class="text-justify">
              La protección de datos es una herramienta para garantizar la
              protección de la información que identifica a cada persona. Es uno
              de los derechos fundamentales en la UE establecidos también en la
              Carta de los Derechos Fundamentales (artículos 7 y 8). Este
              derecho está garantizado para cualquier persona, incluidos
              terceros, cuyos datos, el SEAE y las delegaciones de la Unión
              Europea puedan procesar con un propósito explícito. Todos los
              datos personales se manejan de acuerdo con los actos legislativos
              pertinentes de la UE con respecto al procesamiento de datos
              personales.
            </p>
            <p class="text-justify">
              Para más información sobre nuestra política de Protección de Datos
              (EN) y Declaración de privacidad (ES):
            </p>
            <p>
              <a
                href="https://eeas.europa.eu/headquarters/headquarters-homepage/3032/data-protection_en"
                ><h6>Proteccion de Datos</h6></a
              >
            </p>
            <p>
              <a
                href="https://eeas.europa.eu/sites/eeas/files/eeas_privacy_statement_events_-_meetings_2019_es_-_version_spanish.pdf"
              >
                <h6>Declaracion de privacidad</h6></a
              >
            </p>
          </article>
        </div>
        <div class="col">
          <loginForm></loginForm>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import loginForm from "@/components/LoginForm.vue";

export default {
  name: "Home",
  components: {
    loginForm,
  },
};
</script>
