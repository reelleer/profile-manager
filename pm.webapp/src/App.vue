<template>
  <header>
    <section class="header__deu">
      <div class="container">
        <div class="col-12 py-2 d-flex d-sm-block justify-content-center">
          <a class="navbar-brand" href="/">
            <img
              src="Ue2.png"
              alt="Logo de la Unión Europea"
              width="135"
              height="74"
              class="d-inline-block align-text-center me-2"
            />
            <span class="header__deu-title h1">
              <span class="d-none d-sm-inline d-lg-none"> DUE Nicaragua </span>
              <span class="d-none d-lg-inline">
                Delegación de la Unión Europea en Nicaragua
              </span>
            </span>
          </a>
        </div>
      </div>
    </section>
    <section class="header__erasmus">
      <div class="container">
        <div class="col-12 py-2 d-flex d-sm-block justify-content-center">
          <a class="navbar-brand" href="/">
            <img
              src="Erasmus2.png"
              alt=""
              width="159"
              height="65"
              class="d-inline-block align-text-center"
            />
            <span class="header__erasmus-title h1">
              <span class="d-none d-sm-inline d-md-none"> Nicaragua </span>
              <span class="d-none d-md-inline"> Club Erasmus Nicaragua </span>
            </span>
          </a>
        </div>
      </div>
    </section>
    <section class="header__nav">
      <nav class="navbar navbar-expand-lg navbar-dark py-lg-0">
        <div class="container">
          <button
            class="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNav"
            aria-controls="navbarNav"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>
          <div
            class="collapse navbar-collapse nav justify-content-center"
            id="navbarNav"
          >
            <ul class="navbar-nav">
              <li class="nav-item">
                <router-link class="nav-link text-white px-5" to="/"
                  >Home</router-link
                >
              </li>
              <li class="nav-item">
                <router-link class="nav-link text-white px-5" to="/profile"
                  >Perfil</router-link
                >
              </li>
              <li class="nav-item">
                <router-link class="nav-link text-white px-5" to="/about"
                  >About</router-link
                >
              </li>
            </ul>
          </div>
        </div>
      </nav>
    </section>
  </header>
  <main class="container">
    <router-view />
  </main>
  <footer class="bg-black text-white pt-3 pd-2">
    <div class="container">
      <div class="row justify-content-sm-between">
        <div class="col-12 col-sm-auto text-center">
          <img src="abaco.png" width="180" />
        </div>
        <div class="col-12 col-sm-auto text-center align-items-center">
          <h6>powerby @ASPNicaragua</h6>
        </div>
      </div>
    </div>
  </footer>
</template>
<style></style>
