//import './assets/main.css'
import AppIcon from './components/AppIcon.vue'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

const app = createApp(App)

app.component('AppIcon', AppIcon)

app.use(router)

app.mount('#app')
