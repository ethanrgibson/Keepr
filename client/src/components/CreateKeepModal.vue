<script setup>
import { keepsService } from '@/services/KeepsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { Modal } from 'bootstrap/dist/js/bootstrap.bundle.js';
import { ref } from 'vue';


const editableKeepData = ref({

  name: '',
  img: '',
  description: ''
})


async function createNewKeep() {
  try {
    await keepsService.createKeep(editableKeepData.value)

    editableKeepData.value = {
      name: '',
      img: '',
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
  <div class="modal fade" id="createKeepModal" tabindex="-1" aria-labelledby="createKeepModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <h1 class="modal-title fs-5" id="createKeepModalLabel">Create New Keep!</h1>
          <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
          <form @submit.prevent="createNewKeep()">
            <div class="mb-2">
              <label for="KeepName">Name Your Keep</label>
              <input v-model="editableKeepData.name" type="text" id="KeepName" required minlength="1" maxlength="255">
            </div>
            <div class="mb-2">
              <label for="KeepImgUrl">Image URL...</label>
              <input v-model="editableKeepData.img" type="text" id="KeepImgUrl" required>
            </div>
            <div class="mb-2">
              <label for="KeepDescription">Keep Description</label>
              <textarea v-model="editableKeepData.description" type="text" id="KeepDescription" required minlength="1"
                maxlength="1000"></textarea>
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
label {
  display: block;
  width: 100%;
}

textarea {
  max-height: 25dvh;
  width: 100%;
}
</style>