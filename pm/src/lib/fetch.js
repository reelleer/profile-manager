import axios from 'axios'

const baseURL = import.meta.env.VITE_BASE_API

const send = (url, data, method) => {
  let config = {
    baseURL, //https://example.com/api -> '/profile'
    url,
    method,
    data
  }

  return axios(config) //~task .net
}

export const get = (url) => send(url, null, 'GET')

export const post = (url, data) => send(url, data, 'POST')

export const setUrl = (baseUrl) => (segment) => `${baseUrl}/${segment}`
