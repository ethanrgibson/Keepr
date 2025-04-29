<script setup>
import { Vault } from '@/models/Vault.js';


defineProps({
  vaultProp: { type: Vault, required: true }
})

</script>


<template>
  <RouterLink :to="{ name: 'Vault Page', params: { vaultId: vaultProp.id } }">
    <div class="rounded m-1 position-relative">
      <div>
        <img :src="vaultProp.imgUrl" alt="Image for Vault" class="rounded vault-img">
      </div>
      <div class="vault-name px-1">
        <span class="text-white fs-5">
          {{ vaultProp.name }}
        </span>
      </div>
    </div>
  </RouterLink>
</template>


<style lang="scss" scoped>
.vault-img {

  height: 20dvh;
  width: 100%;
  object-fit: cover;

}

.vault-name {

  position: absolute;
  bottom: 0;
  text-shadow: 1px 1px 2px black;

}
</style>