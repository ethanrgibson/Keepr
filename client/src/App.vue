<script setup>

import CreateKeepModal from './components/CreateKeepModal.vue';
import KeepModal from './components/KeepModal.vue';
import Navbar from './components/Navbar.vue';
import { RouterView } from 'vue-router';

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
</template>

<style lang="scss"></style>
