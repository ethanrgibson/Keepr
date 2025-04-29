import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Vault } from "@/models/Vault.js"
import { AppState } from "@/AppState.js"

class VaultsService {
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    const vault = new Vault(response.data)
    AppState.vaults.push(vault)
  }

  async getVaultsByProfileId(profileId) {
    const response = await api.get(`/api/profiles/${profileId}/vaults`)
    const vaults = response.data.map(pojo => new Vault(pojo))
    AppState.vaults = vaults

  }
}



export const vaultsService = new VaultsService()