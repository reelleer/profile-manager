<script setup>
const props = defineProps({
  iconName: {
    type: String,
    default: 'pencil',
    validator(value) {
      return ['pencil', 'trash', 'plus-square', 'check-square', 'send'].includes(value)
    }
  }
})
</script>
<template>
  <svg width="18" height="18" fill="currentColor">
    <use :xlink:href="`#${props.iconName}`" />
  </svg>
</template>
