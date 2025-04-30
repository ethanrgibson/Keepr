<script setup>
import { AppState } from '@/AppState.js';
import VaultKeepsCard from '@/components/VaultKeepsCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

// Do i need to set an active vault keep as a means of getting the vaultkeepID so i can remove a keep from a vault?


const route = useRoute()
const vault = computed(() => AppState.activeVault)
const keeps = computed(() => AppState.keeps)

onMounted(() => {
  getKeepsInVault()
})

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
  <div class="container">
    <div class="row">
      <div class="col-md-12 col-12">
        <div class="masonry-container">
          <div v-for="keep in keeps" :key="keep.id" class="m-3">
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






@media screen AND (max-width: 768px) {

  .masonry-container {
    columns: 160px
  }


}
</style>