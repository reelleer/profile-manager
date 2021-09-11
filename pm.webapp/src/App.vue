<template>
  <header>
    <div class="container">
      <div class="col-12">
        <a class="" href="#">
          <img
              src="Ue2.png"
              alt=""
              width="90"
              height="50"
              class="d-inline-block align-text-center"
              />
          Delegacion de la Union Europea en Nicaragua
        </a>
      </div>
    </div>
  </header>
  <header>
    <div class="container">
      <div class="col-12 header__erasmus">
        <a class="navbar-brand" href="#">
          <img
              src="Erasmus2.png"
              alt=""
              width="100"
              height="50"
              class="d-inline-block align-text-center"
              />
          Club Erasmus Nicaragua
        </a>
      </div>
    </div>
  </header>
  <header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container">
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse nav justify-content-center" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <router-link class="nav-link" to="/">Home</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/profile">Perfil</router-link>
            </li>
            <li class="nav-item">
              <router-link class="nav-link" to="/about">About</router-link>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  </header>
  <main class="container">
    <router-view />
  </main>
  <footer class="bg-black text-white pt-3 pd-2">
    <div class="container">
      <div class="row justify-content-between">
        <div class="col-4">
          <img src="abaco.png" width="180">
        </div>
        <div class="col-8">
          <h6 class="footer_text">powerby @ASPNicaragua</h6> 
        </div> 
      </div>
    </div>
  </footer>
</template>
<style>
</style>
