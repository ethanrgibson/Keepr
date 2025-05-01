<script setup>
import { AppState } from '@/AppState.js';
import VaultKeepsCard from '@/components/VaultKeepsCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';

// Do i need to set an active vault keep as a means of getting the vaultkeepID so i can remove a keep from a vault?


const route = useRoute()
const router = useRouter()
const vault = computed(() => AppState.activeVault)
const vaultkeeps = computed(() => AppState.vaultKeeps)

onMounted(() => {
  setActiveVault()
})

async function setActiveVault() {

  try {
    const vaultId = route.params.vaultId
    await vaultsService.getVaultById(vaultId)
    getKeepsInVault()
  }
  catch (error) {
    Pop.error(error, 'No vault here!');
    router.push({ name: 'Home' })
  }
}

async function getKeepsInVault() {
  try {
    const vaultId = route.params.vaultId
    await vaultKeepsService.getKeepsInVault(vaultId)

  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>
  <div v-if="vault" class="container-fluid">
    <div class="row">
      <div class="col-md-12 p-0">
        <div class="text-center m-4 position-relative">
          <img :src="vault.imgUrl" alt="Cover Image" class="cover-img rounded img-fluid">
          <div class="vault-name">
            <h1 class="text-white">{{ vault.name }}</h1>
          </div>
        </div>
        <div class="d-flex justify-content-center gap-4">
          <span class="bg-purple rounded-pill px-2"> {{ vaultkeeps.length }} Keeps </span>
        </div>
      </div>
    </div>
  </div>
  <div class="container">
    <div class="row">
      <div class="col-md-12 col-12">
        <div class="masonry-container">
          <div v-for="keep in vaultkeeps" :key="keep.id" class="m-3">
            <VaultKeepsCard :keep="keep" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.masonry-container {
  columns: 400px;
}

.masonry-container>* {
  display: inline-block;
  break-inside: avoid;
}



.vault-name {
  position: absolute;
  bottom: 0;
  right: 0;
  left: 0;
}

h1 {
  text-shadow: 1px 1px 2px black;
}


@media screen AND (max-width: 768px) {

  .masonry-container {
    columns: 160px
  }


}
</style>