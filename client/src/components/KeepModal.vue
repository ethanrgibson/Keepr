<script setup>
import { AppState } from '@/AppState.js';
import { computed } from 'vue';


const keep = computed(() => AppState.activeKeep)


</script>


<template>
  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div v-if="keep" class="container-fluid">
          <div class="row">
            <div class="col-md-6 p-0">
              <div>
                <img :src="keep.imgUrl" :alt="'Image uploaded by ' + keep.creator.name" class="rounded-start  keep-img">
              </div>
            </div>
            <div class="col-md-6">
              <div class="h-100 p-5 d-flex flex-column justify-content-between">
                <div>
                  Place Holder BOIII
                </div>
                <div class="text-center">
                  <span class="fw-bold fs-2 mb-2">{{ keep.name }}</span>
                  <p>{{ keep.description }}</p>
                </div>
                <div class="d-flex justify-content-between align-items-center">
                  <div>
                    <div>
                      <span>PlaceHolder for drop down</span>
                      <button class="btn btn-indigo text-white">
                        Save
                      </button>
                    </div>
                  </div>
                  <div>
                    <img :src="keep.creator.picture" :alt="'Profile Picture of ' + keep.creator.name"
                      class="profile-img me-2">
                    <span>{{ keep.creator.name }}</span>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<style lang="scss" scoped>
.keep-img {

  height: 80dvh;
  width: 100%;
  object-fit: cover;

}

.profile-img {
  max-height: 5dvh;
  aspect-ratio: 1/1;
  border-radius: 50%;
}
</style>