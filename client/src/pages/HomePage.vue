<script setup>
import KeepsCard from '@/components/KeepsCard.vue';
import { keepsService } from '@/services/KeepsService.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted } from 'vue';

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
  <div>
    <KeepsCard />
  </div>
</template>

<style scoped lang="scss"></style>
