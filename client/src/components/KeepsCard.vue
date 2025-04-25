<script setup>
import { Keep } from '@/models/Keep.js';


defineProps({
  keep: { type: Keep, required: true }
})

</script>


<template>
  <div>
    <img :src="keep.imgUrl" :alt="'A Picture Submitted by' + keep.creator.name" class="img-fluid mb-3">
  </div>
</template>


<style lang="scss" scoped></style>