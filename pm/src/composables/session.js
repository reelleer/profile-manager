import { ref, computed } from 'vue'

const user = ref(null)

const login = (data) => {
  localStorage.setItem('user', JSON.stringify(data))
  user.value = data
}

const logout = () => {
  localStorage.removeItem('user')
  user.value = null
}

const isLogged = computed(() => !!user.value)

const fullName = computed(
  () => user.value
    ? `${user.value.firstName } ${user.value.lastName}`
    : ''
)

const token = computed(() => user.value.token)

const userId = computed(() => user.value.id)

export const useSession = () => {
  if(!user.value) {
    const userJSON = localStorage.getItem('user')

    if(userJSON) {
      user.value = JSON.parse(userJSON)
    }
  }

  return {
    isLogged,
    fullName,
    token,
    login,
    logout,
    userId
  }
}

