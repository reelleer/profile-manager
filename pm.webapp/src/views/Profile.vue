<template>
  <p v-if="!ready">Estamos cargando tu perfil.</p>
  <div v-else>
    <h1 class="h2 py-3">Rellene el Formulario para actualizar sus datos</h1>
    <personalInfo
        :address="profile.personalInfo.adress"
        :birthDate = "profile.personalInfo.birthDate"
        :birthPlace = "profile.personalInfo.birthPlace"
        :country = "profile.personalInfo.country"
        :email = "profile.personalInfo.email"
        :facebook = "profile.personalInfo.facebook"
        :instagram = "profile.personalInfo.instagram"
        :key = "profile.personalInfo.id"
        :lastName = "profile.personalInfo.lastName"
        :linkedin = "profile.personalInfo.linkedin"
        :name = "profile.personalInfo.name"
        :phone = "profile.personalInfo.phone"
        :twitter = "profile.personalInfo.twitter"
        :working = "profile.personalInfo.working"
        @pinfo:save="saveInfo"
        ></personalInfo>
    <studiesList
        :items="profile.studies"
        @slist:edit="studyEdit"
        @slist:remove="studyRemove"
        :show="!showForm"
        ></studiesList>
    <button v-if="!showForm" @click="studyNew" class="btn btn-primary">
      <svg width="19" height="18" fill="currentColor">
        <use xlink:href="#plus-square" />
      </svg> Agregar
    </button>
    <studiesForm
        :begin="itemForm.begin"
        :country="itemForm.country"
        :end="itemForm.end"
        :key="editId"
        :study="itemForm.study"
        :type="itemForm.type"
        :university="itemForm.university"
        @sform:cancelar="formCancel"
        @sform:save="saveStudy"
        v-if="showForm"
        ></studiesForm>
    <pollForm
        :activities="profile.poll.activities"
        :contacts="profile.poll.contacts"
        :follower="profile.poll.follower"
        :opportunities="profile.poll.opportunities"
        @poll:save="savePoll"
    ></pollForm>
    <div class="d-flex justify-content-center my-4">
      <button
          class="btn btn-primary btn-lg"
          @click="profileSave"
      >Actualizar</button>
    </div>
  </div>
</template>
<script>
import debounce from 'lodash/debounce'
import personalInfo from '@/components/PersonalInfo.vue'
import pollForm from '@/components/PollForm.vue'
import studiesForm from '@/components/StudiesForm.vue'
import studiesList from '@/components/StudiesList.vue'

const API_URI = process.env.VUE_APP_PM_API;

export default {
  name: 'Profile',
  props: {
    id: { type: String, default: "" }
  },
  components: {
    studiesForm,
    studiesList,
    personalInfo,
    pollForm
  },
  data() {
    return {
      baseURI: API_URI, 
      ready: false,
      showForm: false,
      editId: 0,
      profile: {
        id: "",
        personalInfo: {},
        studies: [],
        poll: {},
      }
    }
  },
  computed: {
    itemForm: function() {
      return this.profile.studies.find(item => item.id == this.editId) || {}
    }
  },
  async beforeMount () {
    if(this.id !== "") {
      this.profile = await this.profileGet(this.id)
    }
    this.ready = true;    
  },
  mounted() {
    if(this.profile.studies.length == 0)
      this.showForm = true;
  },
  methods: {
    formCancel() {
      this.showForm = false;
      this.editId = 0;
    },
    saveStudy(itemForm) {
      this.showForm = false;
      if(this.editId !== 0) {
        let index = this.studyGetIndex(this.studyGetById(this.editId))
        if(index > -1)
          this.profile.studies[index] = { ...itemForm, id: this.editId }
      } else {
        this.profile.studies.push(
          {
            id: Date.now() * -1,
            ...itemForm
          }
        );
      }
      this.editId = 0
    },
    studyNew() {
      this.editId = 0
      this.showForm = true
    },
    studyEdit(id) {
      if(this.showForm) {
        alert("Guarde o cancele la edición actual.")
        return;
      }
      this.editId = id
      this.showForm = true;
    },
    studyRemove(id) {
      let index = this.studyGetIndex(this.studyGetById(id))
      this.profile.studies.splice(index, 1)
    },
    studyGetById(id) {
      return this.profile.studies.find(item => item.id == id)
    },
    studyGetIndex(item) {
      return this.profile.studies.indexOf(item)
    },
    saveInfo(info) {
      this.profile.personalInfo = info
    },
    savePoll(poll) {
      this.profile.poll = poll
    },
    profileSave: debounce(
      async function() {
        let response

        if(this.profile.id === "") {
          response = await this.profilePost({ ...this.profile })
          const data = await response.json();
          this.profile.id = data.id;
          this.profile.studies = data.studies;
        } else {
          response = await this.profilePut(this.profile.id, { ...this.profile })
        }
        console.log(response)
      }
    ),
    async profileGet(id) {
      const response = await this.request(`${this.baseURI}profiles/${id}`) 
      const profile = await response.json()
      return profile;
    },
    async profilePost (data) {
      return await this.request(
        `${this.baseURI}profiles`,
        'POST',
        data
      )
    },
    async profilePut(id, data) {
      return await this.request(
        `${this.baseURI}profiles/${id}`,
        'PUT',
        data
      )
    },
    async request(uri, method = "GET", body){
      let response

      const init = {
        method,
        mode: 'cors',
        credentials: 'omit'
      }
      console.log(uri, method, body, init)
      if (["POST", "PUT"].indexOf(method.toUpperCase()) !== -1)
        response = await fetch (
            uri,
            {
              ...init,
              headers: {
                'Content-Type': 'application/json'
              },
              body: JSON.stringify(body)
            }
        )
      else
        response = await fetch(uri, init)
        
      return response
    }
  }
}
</script>
