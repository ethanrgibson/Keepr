import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js"

class VaultsService {
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    const vault = new Vault(response.data)
    AppState.vaults.push(vault)
  }

  async getVaultsByProfileId(profileId) {
    AppState.vaults = []
    const response = await api.get(`api/profiles/${profileId}/vaults`)
    logger.log(response.data)
    const vaults = response.data.map(pojo => new Vault(pojo))
    AppState.vaults = vaults

  }



  async DeleteVault(vaultId) {
    await api.delete(`api/vaults/${vaultId}`)
    const vaults = AppState.vaults
    const vaultIndex = vaults.findIndex(vault => vault.id == vaultId)
    vaults.splice(vaultIndex, 1)
  }


  async getVaultById(vaultId) {
    AppState.activeVault = null
    const response = await api.get(`/api/vaults/${vaultId}`)
    const vault = new Vault(response.data)
    AppState.activeVault = vault
  }

  async getLoggedInUsersVaults() {
    const response = await api.get('account/vaults')
    const vaults = response.data.map(pojo => new Vault(pojo))
    AppState.myVaults = vaults
  }
}



export const vaultsService = new VaultsService()