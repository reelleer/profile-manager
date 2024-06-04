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

2. Día 2 - Crear proyecto, ruteo, v-if 

  - [Crear proyecto de Vue.js][3]
    - `pnpm create vue@latest`
    - `pnpm dev`
  - [Componentes][4] - Explicación
  - Prepar html base (Iconos)
  - App.vue (layout, llamandos css)
  - Ruteo [Vue Router][5]
  - Instalar [Axios Http][6]
    - `pnpm add axios`
  - Login, hacer llamada a API
    - [*v-if*][7] 
    - Guadar token (storage) - 

3. Día 3 - Components: props, events, and vuelidate.

  - Profile View
  - Personal Info Component
  - [Vuelidate][8]
    - Instalar - `pnpm add @vuelidate/core @vuelidate/validators`
    - Reglas - `const rules = {}`
    - [Dirty state][9]
      - Global auto dirty - `useVuelidate(rules, state, { $autoDirty: true})`

4. Dia 4 - Listado y directivas v-for y key 

  - [v-for & key][10]
  - Componente StudiesList
  - Componente StudyForm  
  - Componente PollForm

5. Día 5 - Mejores prácticas

  - [Simple State Management][11]
    - [Composables][12]
  - Icon gallery
  - [Global Registration][13]


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
