<script setup>
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';



async function createVault() {
  try {
    logger.log('creating vault!')
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
              <input type="text" id="vaultName" required minlength="1" maxlength="255">
            </div>
            <div class="mb-2">
              <label for="vaultImgUrl" class="label-block">Image URL...</label>
              <input type="text" id="vaultImgUrl" required>
            </div>
            <div class="d-flex gap-2 mt-4">
              <div>
                <input type="checkbox" class="ms-2" id="makeVaultPrivate">
              </div>
              <div>
                <label for="MakeVaultPrivate">Make Vault Private?</label>
                <p class="text-grey">Private Vaults Are Only Seen By You</p>
              </div>
            </div>
            <div class="text-end">
              <button type="submit" class="btn btn-purple">Create!</button>
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