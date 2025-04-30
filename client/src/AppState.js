import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,

  /** @type {import('./models/Keep.js').Keep[]} keeps from database*/
  keeps: [],

  /** @type {import('./models/Keep.js').Keep} one specific keep from the database*/
  activeKeep: null,

  /** @type {import('./models/Vault.js').Vault[]} vaults from the database*/
  vaults: [],

  /** @type {import('./models/Vault.js').Vault[]} vaults from the database*/
  myVaults: [],

  /** @type {import('./models/Account.js').Profile} profile from the database*/
  activeProfile: null,

  /** @type {import('./models/Vault.js').Vault} vault from the database*/
  activeVault: null,

  /** @type {import('./models/VaultKeep.js').VaultKeepKept[]} vaultkeeps from the database*/
  vaultKeeps: [],



})

