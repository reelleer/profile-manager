import { helpers } from "@vuelidate/validators";

export const greaterThan = (compare) =>
  helpers.withParams(
    { type: "greaterThan", compare },
    (value) => !helpers.req(value) || Date.parse(compare()) < Date.parse(value)
  );
