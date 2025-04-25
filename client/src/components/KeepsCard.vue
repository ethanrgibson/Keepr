<script setup>
import { Keep } from '@/models/Keep.js';


defineProps({
  keep: { type: Keep, required: true }
})

</script>


<template>
  <div>
    {{ keep }}
  </div>
</template>


<style lang="scss" scoped></style>