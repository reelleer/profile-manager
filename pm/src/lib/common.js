//import { get } from 'fetch.js'

//export const getStudyTypes = () => get('/study')

export const getStudyTypes = () => {
  const studies = [
    { label: 'Licenciatura/Ingeiería', id: 1 },
    { label: 'Postgrado/Especialización', id: 2 },
    { label: 'Maestría', id: 3 },
    { label: 'Doctorado', id: 4 },
    { label: 'Staff Académico', id: 5 },
  ]

  return Promise.resolve({ data: studies })
}
