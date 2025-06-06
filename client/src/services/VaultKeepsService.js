import { api } from "./AxiosService.js"
import { VaultKeepKept } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"
import { logger } from "@/utils/Logger.js"

class VaultKeepsService {

  async createVaultKeep(vaultKeepData) {
    await api.post('api/vaultkeeps', vaultKeepData)
    AppState.activeKeep.kept++
  }

  async getKeepsInVault(vaultId) {
    const response = await api.get(`/api/vaults/${vaultId}/keeps`)
    logger.log(response.data)
    const keeps = response.data.map(pojo => new VaultKeepKept(pojo))
    AppState.vaultKeeps = keeps
  }
  async deleteVaultKeep(vaultKeepId) {
    const response = await api.delete(`api/vaultkeeps/${vaultKeepId}`)
    const vaultKeeps = AppState.vaultKeeps
    const vaultKeepIndex = vaultKeeps.findIndex(keptKeep => keptKeep.vaultKeepId == vaultKeepId)
    vaultKeeps.splice(vaultKeepIndex, 1)
    logger.log(response.data)
  }

}


export const vaultKeepsService = new VaultKeepsService()