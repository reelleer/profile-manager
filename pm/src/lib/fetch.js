import axios from 'axios'

const baseURL = import.meta.env.VITE_BASE_API

const send = (url, data, method) => {
  let config = {
    baseURL,
    url,
    method,
    data
  } 
  
  const userJson = localStorage.getItem('user')

  if(userJson) {
    const userObj = JSON.parse(userJson)

    config = {
      ...config,
      headers: {
        Authorization: 'Bearer ' + userObj.token
      }
    } 
  }

  return axios(config)
} 

export const get = (url) => send(url, null, 'GET')

export const post = (url, data) => send(url, data, 'POST')

export const setUrl = (baseUrl) => (segment) => `${baseUrl}/${segment}`

