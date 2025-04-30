import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { VaultKeep, VaultKeepKept } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"

class VaultKeepsService {
  async deleteVaultKeep(vaultKeepId) {

  }

  async createVaultKeep(vaultKeepData) {
    const response = await api.post('api/vaultkeeps', vaultKeepData)
    const vaultKeep = new VaultKeepKept(response.data)
    AppState.vaultKeeps.push(vaultKeep)
    logger.log(AppState.vaultKeeps)
  }

  async getKeepsInVault(vaultId) {
    const response = await api.get(`/api/vaults/${vaultId}/keeps`)
    const keeps = response.data.map(pojo => new VaultKeepKept(pojo))
    AppState.vaultKeeps = keeps
  }

}


export const vaultKeepsService = new VaultKeepsService()