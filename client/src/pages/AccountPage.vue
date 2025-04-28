<script setup>
import { computed } from 'vue';
import { AppState } from '../AppState.js';

const account = computed(() => AppState.account)

</script>

<template>
  <div class="container-fluid">
    <div v-if="account" class="row">
      <div class="col-md-12 p-0">
        <div class="text-center m-4 position-relative">
          <img :src="account.coverImg" alt="Cover Image" class="cover-img rounded img-fluid">
          <div class="profile-pic-position">
            <img :src="account.picture" alt="Profile Picture" class="profile-pic">
          </div>
        </div>
      </div>
      <div class="row justify-content-around">
        <div class="col-md-4">
          <div class="d-flex gap-3 text-start">
            <span>0 Keeps </span>
            <span>0 Vault</span>
          </div>
        </div>
      </div>
      <div class="row mt-4">
        <div class="col-md-6">
          <div class="text-center">
            <span class="fw-bold fs-3">Vaults</span>
          </div>
        </div>
      </div>

    </div>


    <div v-else>
      <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
    </div>
  </div>
</template>

<style scoped lang="scss">
.cover-img {
  min-height: 45dvh;
}

.profile-pic-position {

  position: absolute;
  right: 0;
  left: 0;
  bottom: -65px;

}

.profile-pic {
  max-height: 15dvh;
  border-radius: 50%;
}
</style>
