<script setup>
import { logger } from '@/utils/Logger.js';




async function createNewKeep(params) {
  logger.log('creating new keep')

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
              <input type="text" id="KeepName">
            </div>
            <div class="mb-2">
              <label for="KeepImgUrl">Image URL...</label>
              <input type="text" id="KeepImgUrl">
            </div>
            <div class="mb-2">
              <label for="KeepDescription">Keep Description</label>
              <textarea type="text" id="KeepDescription"></textarea>
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