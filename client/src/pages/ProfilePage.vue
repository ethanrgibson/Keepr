<script setup>
import { AppState } from '@/AppState.js';
import { profilesService } from '@/services/ProfilesService.js';
import { Pop } from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()
const profile = computed(() => AppState.activeProfile)

onMounted(() => {
  getProfile()

})

async function getProfile() {
  try {
    const profileId = route.params.profileId
    await profilesService.getProfile(profileId)
  }
  catch (error) {
    Pop.error(error);
  }

}

</script>


<template>
  <div>
    Profile
  </div>
</template>


<style lang="scss" scoped></style>