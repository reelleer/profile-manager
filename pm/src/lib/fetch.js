import axios from 'axios'

const baseURL = import.meta.env.VITE_BASE_API

const fetch = axios.create({
  baseURL
})

export const post = (url, data) => fetch.post(url, data)
