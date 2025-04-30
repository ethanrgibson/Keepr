<script setup>
import { AppState } from '@/AppState.js';
import KeepsCard from '@/components/KeepsCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';


const keeps = computed(() => AppState.keeps)


onMounted(() => {
  getAllKeeps()
  getUsersVaults()
})



async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.error(error);
  }
}

async function getUsersVaults() {
  try {
    const profileId = AppState.account?.id
    await vaultsService.getVaultsByProfileId(profileId)
  }
  catch (error) {
    Pop.error(error);
  }

}


</script>

<template>

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

<style scoped lang="scss">
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
