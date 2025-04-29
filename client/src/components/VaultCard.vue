<script setup>
import { AppState } from '@/AppState.js';
import { Vault } from '@/models/Vault.js';
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';

const account = computed(() => AppState.account)

defineProps({
  vaultProp: { type: Vault, required: true }
})


async function deleteVault(vaultId) {

  try {
    const confirmed = await Pop.confirm('Are you sure you want to delete this vault?', 'It will be gone forever!', 'Delete It!', 'No, Stop!')
    if (!confirmed) {
      return
    }
    await vaultsService.DeleteVault(vaultId)
  }
  catch (error) {
    Pop.error(error);
  }

}

</script>


<template>
  <div class="rounded m-1 position-relative">
    <div v-if="vaultProp.creatorId == account?.id" class="p-1 delete-button" @click="deleteVault(vaultProp.id)"
      role="button" title="Delete Keep">
      <span class="bg-white rounded mdi mdi-alpha-x-box text-danger fs-2"></span>
    </div>
    <RouterLink :to="{ name: 'Vault Page', params: { vaultId: vaultProp.id } }">
      <div>
        <img :src="vaultProp.imgUrl" alt="Image for Vault" class="rounded vault-img">
      </div>
      <div class="vault-name px-1">
        <span class="text-white fs-5">
          {{ vaultProp.name }}
        </span>
      </div>
    </RouterLink>
  </div>
</template>


<style lang="scss" scoped>
.vault-img {

  height: 20dvh;
  width: 100%;
  object-fit: cover;

}

.vault-name {

  position: absolute;
  bottom: 0;
  text-shadow: 1px 1px 2px black;
}

.delete-button {
  position: absolute;
  top: 0;
  right: 0;
}
</style>