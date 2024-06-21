# Taller

## Guía 

1. Día 1 - Preparar el entorno
  - [Docker][15] (opcional para usar sql)
  - [Git][14]
    - winget install --id Git.Git -e --source winget
  - Editor de código de su preferencia
    - `winget install Neovim.Neovim`
  - Instalar el *node version manager* para windows [fnm][1]
    - `winget install Schniz.fnm`
    - `notepad $profile`
      - `fnm env --use-on-cd | Out-String | Invoke-Expression`
    - `fnm install --lts` _requiere permisos de administrador_
  - Instalar manejador de paquetes [pnpm][2]
    - `iwr https://get.pnpm.io/install.ps1 -useb | iex` 
    - `pnpm --version`
  - Vefificar .NET 5
  - Clonar proyecto
    - `cd <path\to\project>`
    - `git clone https://github.com/reelleer/profile-manager.git` 
  - Preparar BD
    - `.\create-container.ps1`
  - `dotnet run`
  - Opcional ejecutar frontend
    - `pnpm install`
    - `pnpm serve`

2. Día 2 - Crear proyecto, structura del proyecto, componentes y login form 

  - [Crear proyecto de Vue.js][3]
    - `pnpm create vue@latest`
    - `pnpm dev`
  - `node --version > .node-version`
  - How VueJs Work?
    - [Componentes][4] - Explicación
    - File structure
  - Copiar archivos estáticos
  - _index.html_ (add css, js, iconos)
  - _main.js_ (remove defualt css)
  - _App.vue_ (layout, llamandos css)
  - _ProfileView.vue_ [html](ProfileView.html)
  - Actualizar [ruta][5]
  - Login component, hacer llamadas a la API
    - [_v-model_][16]
    - [_v-if_][7] 
    - [Axios][6] `pnpm add axios`
    - [_.env_][17] file
    - _fetch.js_
    - Guadar token (local storage)
  - [Navigation guards][18]
  - `router.push` (after logon navigate to profile)

3. Día 3 - Components: props and vuelidate.

  - Personal Info Component [html](PersonalInfo.html)
    - html and internal data
    - `defineProps()` [macro][19]
    - `formatDate` input#date 
    - [Vuelidate][8]
    - `pnpm add @vuelidate/core @vuelidate/validators`
    - `const rules = {}`
    - `v.name.$model`
    - `:class="{ 'is-invalid': v.name.$error }"`
    - `const isValid = await v.value.$validate()`
    - [Dirty state][9]
    - [Global auto dirty][20] - `useVuelidate(rules, state, { $autoDirty: true})`
    - `@input="onInput"` on parent element
    - Validate login form
  - _ProfileView_
    - `import PersonalInfo`
    - fetch user profile

4. Día 4 - Listado y directivas v-for, key, emit 

  - _StudiesList_ [HTML](StudiesList.html)
    - [v-for & key][10]
    - `v-for="study in props.items"`
    - `:key="study.id"`
    - `defineProps({ items: { type: Array, default: [] }})`
    - `defineEmits(['study-edit', 'study-remove'])`
    - `@click="onEdit(study.id)"`
    - `emit('studyEdit', id)`
    - `formatDate()`
  - _StudyForm_ [html](StudyForm.html) 
    - `defineEmits(['studyCancel', 'studySave')` 
    - `defineProps({ study: { type: Object, required: true }})`
    - _lib/validators.js_ [Vuelidate helpers][21] 
    - `emit('studyCancel')`
    - `emit('studySave)`
  - Componente PollForm [html](PollForm.html)
    - data
    - validation
    - emit event
  - Add below html _ProfileView_ 

````
  <h2 class="h3 border-bottom border-dark py-2">Historial Académico</h2>
  ...
  <button v-if="!showForm" @click="onStudyNew" class="btn btn-primary">
    <svg width="19" height="18" fill="currentColor">
      <use xlink:href="#plus-square" />
    </svg>
    Agregar
  </button>
````
  - _ProfileView_
    - `import StudyForm`
    - handle _StudyForm_ events
    - 'let studyForm'
    - `let studyId`
    - `import PollForm`
    - handle _PollForm_ events
    - save profile data

5. Día 5 - Mejores prácticas

  - [Simple State Management][11]
  - [Composables][12]
  - _src/composables/session.js_
  - Actualizar
    - LoginForm
    - fetch
    - router/index.js
    - ProfileView
  - [Global Registration][13]
  - Trabajando con una lista despegable
  - [Lifecycle Hooks][22] Al mostrar StudyFrom enfocar tipo de estudio

## Extras

**Self signed certificate**

- `git config --global http.sslVerify false`
- `pnpm config --global set strict-ssl false`


[1]: https://github.com/Schniz/fnm "Fast Node Manager"
[2]: https://pnpm.io/installation "Instalar pnpm" 
[3]: https://vuejs.org/guide/quick-start.html#creating-a-vue-application "Iniciar Vue.js"
[4]: https://vuejs.org/guide/introduction.html#what-is-vue "¿Qué es Vue?"
[5]: https://router.vuejs.org/ "Vue Router"
[6]: https://axios-http.com/docs/instance "Axios HTTP"
[7]: https://vuejs.org/guide/essentials/conditional.html "Conditional Rendering"
[8]: https://vuelidate-next.netlify.app/ "Vuelidate" 
[9]: https://vuelidate-next.netlify.app/guide.html#the-dirty-state
[10]: https://vuejs.org/guide/essentials/list.html "Renderizado de listas"
[11]: https://vuejs.org/guide/scaling-up/state-management.html#simple-state-management-with-reactivity-api "Simplete State Management"
[12]: https://vuejs.org/guide/reusability/composables.html "Composable"
[13]: https://vuejs.org/guide/components/registration.html "Components Registration"
[14]: https://git-scm.com/downloads "Git"
[15]: https://docs.docker.com/desktop/install/windows-install/ "Instalar Docker en Windows"
[16]: https://vuejs.org/guide/essentials/forms.html "Form binding"
[17]: https://vitejs.dev/guide/env-and-mode.html ".env* files"
[18]: https://router.vuejs.org/guide/advanced/navigation-guards.html "Navigation Guards"
[19]: https://vuejs.org/guide/components/props.html "Vue Props"
[20]: https://vuelidate-next.netlify.app/advanced_usage.html#providing-global-config-to-your-vuelidate-instance "Vuelidate global Configuration"
[21]: https://vuelidate-next.netlify.app/custom_validators.html#list-of-helpers "Vuelidate helpers"
[22]: https://vuejs.org/guide/essentials/lifecycle.html "Lifecycle Hooks"
