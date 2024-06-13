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
    - `cd <path>`
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
    - fetch data from api 
    - add Authorization header
    - `formatDate` input#date 
  - [Vuelidate][8]
    - `pnpm add @vuelidate/core @vuelidate/validators`
    - import computed
    - `const rules = {}`
    - `v.name.$model`
    - `:class="{ 'is-invalid': v.name.$error }"`
    - `const isValid = await v.value.$validate()`
    - [Dirty state][9]
    - [Global auto dirty][20] - `useVuelidate(rules, state, { $autoDirty: true})`
    - Validate login form
      - `const isValid = await v.value.$validate()`

4. Dia 4 - Listado y directivas v-for, key, emit 

  - [v-for & key][10]
  - _StudiesList_ [HTML](StudiesList.html)
  - Profile View
    - ``
    - import _StudiesList_
    - add _new_ button

    <h2 class="h3 border-bottom border-dark py-2">Historial Académico</h2>
    ...
    <button v-if="!showForm" @click="onStudyNew" class="btn btn-primary">
      <svg width="19" height="18" fill="currentColor">
        <use xlink:href="#plus-square" />
      </svg>
      Agregar
    </button>

  - _StudyForm_ [html](StudyForm.html) 
    - `defineEmits(['study:cancel', 'study:save')` 
    - _lib/validators.js_ [Vuelidate helpers][21] 
    - save
  - _ProfileView_
    - `let studyId
  - _StudiesList_
    - `defineEmits(['study:edit', 'study:remove'])`
    - `@click="onEdit(study.id)"`
    - `emit('study:edit', id)`
  - _ProfileView_
    - 
  - Componente PollForm

5. Día 5 - Mejores prácticas

  - [Simple State Management][11]
    - [Composables][12]
  - Icon gallery
  - [Global Registration][13]

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
