<script setup>
import { AppState } from '@/AppState.js';
import { Keep } from '@/models/Keep.js';
import { keepsService } from '@/services/KeepsService.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';
import { useRoute } from 'vue-router';



const account = computed(() => AppState.account)


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


async function removeKeepFromVault() {
  try {

    const confirmed = await Pop.confirm('Sure you want to remove this keep from this vault?')

    if (!confirmed) {
      return
    }

    // await vaultKeepsService.deleteVaultKeep(currentvaultKeep.value)
  }
  catch (error) {
    Pop.error(error);
  }

}

</script>


<template>
  <div class="position-relative">
    <div v-if="keep.creatorId == account?.id" @click="removeKeepFromVault()" class="p-1 delete-button" role="button"
      title="Delete Keep">
      <span class=" bg-white rounded mdi mdi-alpha-x-box text-danger fs-2"></span>
    </div>
    <div @click="setActiveKeep(keep.id)" role="button" type="button" title="View Keep Information"
      data-bs-toggle="modal" data-bs-target="#keepModal" class="rounded shadow-lg">
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
  text-shadow: 1px 1px 4px black;
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

.delete-button {
  position: absolute;
  top: 0;
  right: 0;
}
</style>