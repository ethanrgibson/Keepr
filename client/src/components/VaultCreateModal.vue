<script setup>
import { vaultsService } from '@/services/VaultsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { Modal } from 'bootstrap/dist/js/bootstrap.bundle.js';
import { ref } from 'vue';


const editableVaultData = ref({

  name: '',
  img: '',
  isPrivate: false,
  description: ''
})


async function createVault() {
  try {

    await vaultsService.createVault(editableVaultData.value)

    editableVaultData.value = {
      name: '',
      img: '',
      isPrivate: false,
      description: ''
    }
    Modal.getOrCreateInstance('#createKeepModal').hide()

  }
  catch (error) {
    Pop.error(error);
  }

}




</script>


<template>
  <div class="modal fade" id="createVaultModal" tabindex="-1" aria-labelledby="createVaultModalLabel"
    aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="createVaultModalLabel">Create New Vault!</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createVault()">
            <div class="mb-2">
              <label for="vaultName" class="label-block">Title</label>
              <input v-model="editableVaultData.name" type="text" id="vaultName" required minlength="1" maxlength="255">
            </div>
            <div class="mb-2">
              <label for="vaultImgUrl" class="label-block">Image URL...</label>
              <input v-model="editableVaultData.img" type="text" id="vaultImgUrl" required minlength="1" maxlength="1000">
            </div>
            <div class="d-flex gap-2 mt-4">
              <div>
                <input v-model="editableVaultData.isPrivate" type="checkbox" class="ms-2" id="makeVaultPrivate">
              </div>
              <div>
                <label for="MakeVaultPrivate">Make Vault Private?</label>
                <p class="text-grey">Private Vaults Are Only Seen By You</p>
              </div>
            </div>
            <div class="text-end">
              <button type="submit" class="btn btn-purple" data-bs-dismiss="modal">Create!</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.label-block {
  display: block;
  width: 100%;
}
</style>