<script setup>
import { AppState } from '@/AppState.js';
import { accountService } from '@/services/AccountService.js';
import { Pop } from '@/utils/Pop.js';
import { onMounted, ref } from 'vue';


const editableAccountData = ref({
  name: '',
  picture: '',
  coverImg: ''

})

onMounted(() => {
  const account = AppState.account

  editableAccountData.value = { ...account }
})

async function updateAccount() {

  try {
    await accountService.updateAccount(editableAccountData.value)

    editableAccountData.value = {
      name: '',
      picture: '',
      coverImg: ''

    }
  }
  catch (error) {
    Pop.error(error);
  }

}


</script>


<template>
  <div class="d-flex flex-column shadow-lg rounded p-3 my-2 text-center">
    <h2>Update Your Account</h2>
    <form @submit.prevent="updateAccount()">
      <div class="mb-3">
        <label for="accountName">Account Name</label>
        <input v-model="editableAccountData.name" type="text" name="name" id="accountName" required maxlength="100">
      </div>
      <div class="mb-3">
        <label for="accountPicture">Picture</label>
        <input v-model="editableAccountData.picture" type="text" name="picture" id="accountPicture" required
          maxlength="1000">
      </div>
      <div class="mb-3">
        <label for="accountCoverImg">Cover Image</label>
        <input v-model="editableAccountData.coverImg" type="text" name="coverImg" id="accountCoverImg" required
          maxlength="1000">
      </div>
      <div class="text-end">
        <button class="btn btn-purple text-dark" type="submit">Save</button>
      </div>
    </form>
  </div>

</template>


<style lang="scss" scoped>
label {
  display: block;
}

input {
  width: 100%;
}
</style>