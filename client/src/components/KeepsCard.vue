<script setup>
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';
import { Pop } from '@/utils/Pop.js';


defineProps({
  keep: { type: Keep, required: true }
})

async function setActiveKeep(keepId) {

  try {
    await keepsService.setActiveKeep(keepId)
  }
  catch (error) {
    Pop.error(error);
  }

}

</script>


<template>
  <div @click="setActiveKeep(keep.id)" role="button" type="button" title="View Keep Information" data-bs-toggle="modal"
    data-bs-target="#keepModal" class="rounded shadow-lg position-relative">
    <div class="">
      <img :src="keep.imgUrl" :alt="'A Picture Submitted by' + keep.creator.name" class="img-fluid rounded">
    </div>
    <div class="profile-info p-2 d-flex justify-content-between align-items-center">
      <div>
        <b class="keep-name text-white fs-5">{{ keep.name }}</b>
      </div>
      <div>
        <img :src="keep.creator.picture" :alt="'Profile picture for ' + keep.creator.name" class="profile-img">
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.keep-name {
  text-shadow: 1px 1px 2px black;
}

.profile-img {
  max-height: 5dvh;
  aspect-ratio: 1/1;
  border-radius: 50%;
}

.profile-info {
  position: absolute;
  bottom: 0;
  width: 100%;
}
</style>