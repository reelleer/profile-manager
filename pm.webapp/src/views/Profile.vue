<template>
  <p v-if="!ready">Estamos cargando tu perfil.</p>
  <div v-else>
    <h1 class="h2 py-3">Rellene el Formulario para actualizar sus datos</h1>
    <personalInfo
      :address="profile.personalInfo.address"
      :birthDate="profile.personalInfo.birthDate"
      :birthPlace="profile.personalInfo.birthPlace"
      :country="profile.personalInfo.country"
      :email="profile.personalInfo.email"
      :facebook="profile.personalInfo.facebook"
      :instagram="profile.personalInfo.instagram"
      :key="profile.personalInfo.id"
      :lastName="profile.personalInfo.lastName"
      :linkedin="profile.personalInfo.linkedin"
      :name="profile.personalInfo.name"
      :phone="profile.personalInfo.phone"
      :twitter="profile.personalInfo.twitter"
      :working="profile.personalInfo.working"
      @pinfo:save="saveInfo"
    ></personalInfo>
    <studiesList
      :items="profile.studies"
      @slist:edit="studyEdit"
      @slist:remove="studyRemove"
      :show="!showForm"
    ></studiesList>
    <p v-show="v$.profile.studies.$error" class="my-4 text-danger">
      Debe agregar al menos un estudio realizado con el programa Erasmus.
    </p>
    <button v-if="!showForm" @click="studyNew" class="btn btn-primary">
      <svg width="19" height="18" fill="currentColor">
        <use xlink:href="#plus-square" />
      </svg>
      Agregar
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
      <button class="btn btn-primary btn-lg" @click="profileSave">
        <svg
          class="me-1"
          :class="{ 'color-spin': this.sending }"
          fill="currentColor"
          height="18"
          role="button"
          width="18"
        >
          <use xlink:href="#send" />
        </svg>
        Actualizar
      </button>
    </div>
  </div>
</template>
<script>
import debounce from "lodash/debounce";
import personalInfo from "@/components/PersonalInfo.vue";
import pollForm from "@/components/PollForm.vue";
import studiesForm from "@/components/StudiesForm.vue";
import studiesList from "@/components/StudiesList.vue";
import useVuelidate from "@vuelidate/core";
import { required, minLength } from "@vuelidate/validators";

const API_URI = process.env.VUE_APP_PM_API;

export default {
  name: "Profile",
  setup() {
    return { v$: useVuelidate() };
  },
  props: {
    id: { type: String, default: "" },
  },
  components: {
    studiesForm,
    studiesList,
    personalInfo,
    pollForm,
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
      },
      sending: false,
    };
  },
  validations() {
    return {
      profile: {
        studies: { required, minLength: minLength(1) },
      },
    };
  },
  computed: {
    itemForm: function () {
      return this.profile.studies.find((item) => item.id == this.editId) || {};
    },
  },
  async beforeMount() {
    const data = localStorage.getItem("user");
    if (data) {
      const user = JSON.parse(data);
      this.profile = await this.profileGet(user.id);

      if (!this.profile.studies || this.profile.studies.length == 0)
        this.showForm = true;
    }
    this.ready = true;
  },
  methods: {
    formCancel() {
      this.showForm = false;
      this.editId = 0;
    },
    saveStudy(itemForm) {
      this.showForm = false;
      if (this.editId !== 0) {
        let index = this.studyGetIndex(this.studyGetById(this.editId));
        if (index > -1)
          this.profile.studies[index] = { ...itemForm, id: this.editId };
      } else {
        this.profile.studies.push({
          id: Symbol(itemForm.study),
          ...itemForm,
        });
      }
      this.editId = 0;
    },
    studyNew() {
      this.editId = 0;
      this.showForm = true;
    },
    studyEdit(id) {
      if (this.showForm) {
        alert("Guarde o cancele la edición actual.");
        return;
      }
      this.editId = id;
      this.showForm = true;
    },
    studyRemove(id) {
      let index = this.studyGetIndex(this.studyGetById(id));
      this.profile.studies.splice(index, 1);
    },
    studyGetById(id) {
      return this.profile.studies.find((item) => item.id == id);
    },
    studyGetIndex(item) {
      return this.profile.studies.indexOf(item);
    },
    saveInfo(info) {
      this.profile.personalInfo = info;
    },
    savePoll(poll) {
      this.profile.poll = poll;
    },
    profileSave: debounce(async function () {
      if (this.sending) return;

      const isOk = await this.v$.$validate();

      if (isOk) {
        let response;

        this.sending = true;

        for (let i = 0; i < 3; i++) {
          try {
            if (this.profile.id === "") {
              response = await this.profilePost({ ...this.profile });
            } else {
              response = await this.profilePut(this.profile.id, {
                ...this.profile,
              });
            }
            break;
          } catch (er) {
            console.error(er);
          }
        }

        this.sending = false;

        if (response == undefined)
          alert("El servidor no responde. Por favor intente más tarde.");
        else if (response.ok) {
          const user = JSON.parse(localStorage.getItem("user"));

          user.firstName = this.profile.personalInfo.name;
          user.lastName = this.profile.personalInfo.lastName;

          localStorage.setItem("user", JSON.stringify(user));

          this.$router.push({ name: "ProfileEnd" });
        } else {
          alert(
            "Su perfil no se pudo almacenar, por favor intente en un minuto."
          );
        }
        console.log(response);
      }
    }, 300),
    async profileGet(id) {
      const response = await this.request(`${this.baseURI}profiles/${id}`);
      const profile = await response.json();
      return profile;
    },
    async profilePost(data) {
      return await this.request(`${this.baseURI}profiles`, "POST", data);
    },
    async profilePut(id, data) {
      return await this.request(`${this.baseURI}profiles/${id}`, "PUT", data);
    },
    async request(uri, method = "GET", body) {
      const user = JSON.parse(localStorage.getItem("user"));

      let response;

      const init = {
        method,
        headers: {
          Authorization: "Bearer " + user.token,
        },
      };

      if (["POST", "PUT"].indexOf(method.toUpperCase()) !== -1)
        response = await fetch(uri, {
          ...init,
          headers: {
            ...init.headers,
            "Content-Type": "application/json",
          },
          body: JSON.stringify(body),
        });
      else response = await fetch(uri, init);

      console.log(uri, method, body, init, response);

      if (response.status == 401) {
        localStorage.removeItem("user");
        this.$router.push({ name: "home" });
      }

      return response;
    },
  },
};
</script>
