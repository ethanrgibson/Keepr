import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { VaultKeep } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"

class VaultKeepsService {

  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    const vaultKeep = new VaultKeep(response.data)
    AppState.vaultKeep.push(vaultKeep)
    logger.log(vaultKeep)
  }

  async getKeepsInVault(vaultId) {
    const response = await api.get(`/api/vaults/${vaultId}/keeps`)
    const keeps = response.data.map(pojo => new Keep(pojo))
    AppState.keeps = keeps
  }

}


export const vaultKeepsService = new VaultKeepsService()