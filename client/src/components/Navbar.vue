<script setup>
import { ref, watch } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';

const theme = ref(loadState('theme') || 'light')

function toggleTheme() {
  theme.value = theme.value == 'light' ? 'dark' : 'light'
}

watch(theme, () => {
  document.documentElement.setAttribute('data-bs-theme', theme.value)
  saveState('theme', theme.value)
}, { immediate: true })

</script>

<template>
  <nav class="navbar navbar-expand-md border-bottom border-dark">
    <div class="container gap-2">
      <RouterLink :to="{ name: 'Home' }" class="d-flex align-items-center text-dark">
        <div class="rounded bg-purple px-2">
          <p class="m-0 fs-5">Home</p>
        </div>
      </RouterLink>
      <!-- TODO make this collapse not so weird -->
      <div class="d-flex align-items-center gap-4">
        <div class="ms-3 text-center">
          <div class="dropdown">
            <button class="btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
              Create
            </button>
            <ul class="dropdown-menu text-center bg-purple-subtle">
              <li type="button" class="btn" data-bs-toggle="modal" data-bs-target="#createKeepModal">
                New Keep </li>
              <br>
              <li>New Vault</li>
            </ul>
          </div>
        </div>
      </div>
      <div class="text-center">
        <div class="text-dark">
          <b>Keeper Co.</b>
        </div>
      </div>
      <!-- collapse button -->
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-links"
        aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
        <span class="mdi mdi-menu text-light"></span>
      </button>
      <!-- collapsing menu -->
      <div class="collapse navbar-collapse " id="navbar-links">
        <!-- LOGIN COMPONENT HERE -->
        <div class="ms-auto">
        </div>
        <Login />
      </div>
    </div>
  </nav>
</template>

<style lang="scss" scoped>
a {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
