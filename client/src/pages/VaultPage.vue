<script setup>
import { AppState } from '@/AppState.js';
import { vaultsService } from '@/services/VaultsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';


const route = useRoute()

const vault = computed(() => AppState.activeVault)

onMounted(() => {
  getKeepsInVault()
})

async function getKeepsInVault() {
  try {
    const vaultId = route.params.vaultId
    await vaultsService.getKeepsInVault(vaultId)

  }
  catch (error) {
    Pop.error(error);
  }

}

</script>


<template>
  Hello Hi
</template>


<style lang="scss" scoped></style>