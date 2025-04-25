<script setup>
import { Keep } from '@/models/Keep.js';


defineProps({
  keep: { type: Keep, required: true }
})

</script>


<template>
  <div class="rounded shadow-lg">
    <img :src="keep.imgUrl" :alt="'A Picture Submitted by' + keep.creator.name" class="img-fluid rounded">
  </div>
</template>


<style lang="scss" scoped></style>