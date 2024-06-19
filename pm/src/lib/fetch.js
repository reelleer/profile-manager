import axios from 'axios'
import { useSession } from '../composables/session.js'

const { isLogged,  token } = useSession()

const baseURL = import.meta.env.VITE_BASE_API

const send = (url, data, method) => {
  let config = {
    baseURL,
    url,
    method,
    data
  } 
  
  if(isLogged.value) {
    config = {
      ...config,
      headers: {
        Authorization: 'Bearer ' + token.value
      }
    } 
  }

  return axios(config)
} 

export const get = (url) => send(url, null, 'GET')

export const post = (url, data) => send(url, data, 'POST')

export const put = (url, data) => send(url, data, 'PUT')

export const setUrl = (baseUrl) => (segment) => `${baseUrl}/${segment}`

