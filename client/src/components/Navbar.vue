<script setup>
import { AppState } from '@/AppState.js';
import Login from './Login.vue';
import { computed } from 'vue';

const account = computed(() => AppState.account)



</script>

<template>
  <nav class="navbar navbar-expand-md border-bottom border-dark">
    <div class="container gap-2">
      <RouterLink :to="{ name: 'Home' }" class="d-flex align-items-center text-dark">
        <div class="rounded bg-purple px-2">
          <p class="m-0 fs-5">Home</p>
        </div>
      </RouterLink>
      <div v-if="account" class="d-flex align-items-center gap-4">
        <div class="ms-3 text-center">
          <div class="dropdown">
            <button class=" btn dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
              Create
            </button>
            <ul class="dropdown-menu bg-purple text-center">
              <li role="button" class="btn" data-bs-toggle="modal" data-bs-target="#createKeepModal">
                New Keep </li>
              <br>
              <li class="dropdown-item btn" role="button" data-bs-toggle="modal" data-bs-target="#createVaultModal">New
                Vault</li>
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
