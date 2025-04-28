<script setup>

import CreateKeepModal from './components/CreateKeepModal.vue';
import KeepModal from './components/KeepModal.vue';
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';
import VaultCreateModal from './components/VaultCreateModal.vue';

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <RouterView />
  </main>


  <KeepModal />
  <CreateKeepModal />
  <VaultCreateModal />
</template>

<style lang="scss"></style>
