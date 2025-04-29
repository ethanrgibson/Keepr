<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import { Pop } from '@/utils/Pop.js';
import { vaultsService } from '@/services/VaultsService.js';

const account = computed(() => AppState.account)



onMounted(() => {
  getMyVaults()
})

async function getMyVaults() {

  try {
    const profileId = account.value.id
    await vaultsService.getVaultsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>

<template>
  <div v-if="account" class="container-fluid">
    <div class="row">
      <div class="col-md-12 p-0">
        <div class="text-center m-4 position-relative">
          <img :src="account.coverImg" alt="Cover Image" class="cover-img rounded img-fluid">
          <div class="profile-pic-position">
            <img :src="account.picture" alt="Profile Picture" class="profile-pic">
          </div>
        </div>
        <br>
        <br>
        <div class="d-flex gap-5 align-items-center justify-content-center">
          <div>
            <h1>{{ account.name }}</h1>
          </div>
        </div>
        <div class="d-flex justify-content-center gap-4">
          <span> 0 Keeps </span>
          <span>0 Vault</span>
        </div>
      </div>
    </div>
  </div>
  <div v-else>
    <h1>Loading... <i class="mdi mdi-loading mdi-spin"></i></h1>
  </div>
  <div class="container">
    <div class="row justify-content-start">
      <div class="col-md-4">
        <div class="text-center">
          <span class="fw-bold fs-2">Vaults</span>
        </div>
      </div>
    </div>
    <div class="row">
      Vaults
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

.masonry-container {
  columns: 400px;
}

.masonry-container>* {
  display: inline-block;
  break-inside: avoid;
}






@media screen AND (max-width: 768px) {

  .masonry-container {
    columns: 160px
  }


}
</style>
