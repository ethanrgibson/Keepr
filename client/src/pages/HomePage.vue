<script setup>
import { AppState } from '@/AppState.js';
import KeepsCard from '@/components/KeepsCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';


const keeps = computed(() => AppState.keeps)


onMounted(() => {
  getAllKeeps()
})


async function getAllKeeps() {
  try {
    await keepsService.getAllKeeps()
  }
  catch (error) {
    Pop.error(error);
  }
}


</script>

<template>

  <div class="container">
    <div class="row">
      <div v-for="keep in keeps" :key="keep.id" class="col-md-12">
        <div>
          <KeepsCard :keep="keep" />
        </div>
      </div>
    </div>
  </div>

</template>

<style scoped lang="scss"></style>
