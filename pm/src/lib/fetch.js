import axios from 'axios'
import { useSession } from '../composables/session.js'

const baseURL = import.meta.env.VITE_BASE_API

const { isLogged, token, logout } = useSession()

const send = (url, data, method) => {
  let config = {
    baseURL, //https://example.com/api -> '/profile'
    url,
    method,
    data
  }

  if (isLogged.value) {
    config = {
      ...config,
      headers: {
        Authorization: 'Bearer ' + token.value
      }
    }
  }

  return axios(config).catch((err) => {
    if (err.response.status === 401) logout()

    return Promise.reject(err)
  }) //~task .net
}

export const get = (url) => send(url, null, 'GET')

export const post = (url, data) => send(url, data, 'POST')

export const setUrl = (baseUrl) => (segment) => `${baseUrl}/${segment}`

export const put = (url, data) => send(url, data, 'PUT')
