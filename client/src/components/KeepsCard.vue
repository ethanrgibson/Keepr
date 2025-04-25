<script setup>
import { Keep } from '@/models/Keep.js';


defineProps({
  keep: { type: Keep, required: true }
})

</script>


<template>
  <div class="rounded shadow-lg">
    <div class="position-relative">
      <img :src="keep.imgUrl" :alt="'A Picture Submitted by' + keep.creator.name" class="img-fluid rounded">
      <div>
        <b class="keep-name text-dark fs-5">{{ keep.name }}</b>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.keep-name {

  position: absolute;
  bottom: 0;

}
</style>