import { unref } from 'vue'
import { helpers } from '@vuelidate/validators'

export const greaterThan = (compare) => helpers.withMessage(
  "Debe ser mayor a la fecha inicial",
  helpers.withParams(
    { type: "greaterThan", compare },
    (value) => 
      !helpers.req(value) || Date.parse(unref(compare)) < Date.parse(value)
   )
)
