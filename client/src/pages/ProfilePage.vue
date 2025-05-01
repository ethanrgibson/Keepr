<script setup>
import { AppState } from '@/AppState.js';
import KeepsCard from '@/components/KeepsCard.vue';
import VaultCard from '@/components/VaultCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { profilesService } from '@/services/ProfilesService.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, watch } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const profile = computed(() => AppState.activeProfile)
const vaults = computed(() => AppState.vaults)
const keeps = computed(() => AppState.profileKeeps)


watch(route, () => {
  getProfile()
  getVaultsByProfileId()
  getKeepsByProfileId()
}, { immediate: true })

async function getProfile() {
  try {
    const profileId = route.params.profileId
    await profilesService.getProfile(profileId)
  }
  catch (error) {
    Pop.error(error);
  }

}

async function getVaultsByProfileId() {
  try {
    const profileId = route.params.profileId
    await vaultsService.getVaultsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function getKeepsByProfileId() {
  try {

    const profileId = route.params.profileId
    await keepsService.getKeepsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error);
  }

}

</script>


<template>
  <div v-if="profile" class="container-fluid">
    <div class="row">
      <div class="col-md-12 p-0">
        <div class="text-center m-4 position-relative">
          <img :src="profile.coverImg" alt="Cover Image" class="cover-img rounded img-fluid">
          <div class="profile-pic-position">
            <img :src="profile.picture" alt="Profile Picture" class="profile-pic">
          </div>
        </div>
        <br>
        <br>
        <div class="d-flex gap-5 align-items-center justify-content-center">
          <div>
            <h1>{{ profile.name }}</h1>
          </div>
        </div>
        <div class="d-flex justify-content-center gap-4">
          <span class="bg-purple rounded-pill px-2">{{ vaults.length }} Vaults</span>
          <span class="bg-purple rounded-pill px-2"> {{ keeps.length }} Keeps</span>
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
      <div v-for="vault in vaults" :key="vault.id" class="col-md-3">
        <VaultCard :vaultProp="vault" />
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row justify-content-start">
      <div class="col-md-4">
        <div class="text-center">
          <span class="fw-bold fs-2">Keeps</span>
        </div>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row">
      <div class="col-md-12 col-12">
        <div class="masonry-container">
          <div v-for="keep in keeps" :key="keep.id" class="m-3">
            <KeepsCard :keep="keep" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
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