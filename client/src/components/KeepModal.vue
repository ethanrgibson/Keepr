<script setup>
import { AppState } from '@/AppState.js';
import { vaultKeepsService } from '@/services/VaultKeepsService.js';
import { logger } from '@/utils/Logger.js';
import { Pop } from '@/utils/Pop.js';
import { computed } from 'vue';


const keep = computed(() => AppState.activeKeep)
const myVaults = computed(() => AppState.vaults.filter(vault => vault.creatorId == AppState.account?.id))

async function createVaultKeep() {

  try {
    logger.log('button working')

  }
  catch (error) {
    Pop.error(error);
  }

}

</script>


<template>
  <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="keepModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
      <div class="modal-content">
        <div v-if="keep" class="container-fluid">
          <div class="row">
            <div class="col-md-6 col-12 p-0">
              <div>
                <img :src="keep.imgUrl" :alt="'Image uploaded by ' + keep.creator.name" class="rounded-start  keep-img">
              </div>
            </div>
            <div class="col-md-6 col-12">
              <div class="h-100 p-5 d-flex flex-column justify-content-between">
                <div class="d-flex justify-content-center gap-4">
                  <span class="fs-4 m-1 mdi mdi-eye">{{ keep.views }}</span>
                  <span class="fs-4 m-1 mdi mdi-alpha-k-box-outline">0</span>
                </div>
                <div class="text-center">
                  <span class="fw-bold fs-2 mb-2">{{ keep.name }}</span>
                  <p>{{ keep.description }}</p>
                </div>
                <div class="d-flex justify-content-between align-items-center gap-3">
                  <div>
                    <div class="d-flex gap-2">
                      <form @submit.prevent="createVaultKeep()">
                        <select class="form-select" id="">
                          <option selected disabled value="">Add To A Vault</option>
                          <option v-for="vault in myVaults" :key="'Add to vault ' + vault.id" :value="vault.id">
                            {{ vault.name }}
                          </option>
                        </select>
                        <div>
                          <button type="submit" class="btn btn-indigo text-white">
                            Save
                          </button>
                        </div>
                      </form>
                    </div>
                  </div>
                  <div>
                    <RouterLink :to="{ name: 'Profile Page', params: { profileId: keep.creatorId } }">
                      <img :src="keep.creator.picture" :alt="'Profile Picture of ' + keep.creator.name"
                        class="profile-img me-2" data-bs-dismiss="modal">
                      <span>{{ keep.creator.name }}</span>
                    </RouterLink>
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

a {
  text-decoration: none;
  color: black;

}
</style>