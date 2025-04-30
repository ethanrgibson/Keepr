import { api } from "./AxiosService.js"
import { VaultKeepKept } from "@/models/VaultKeep.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"

class VaultKeepsService {
  async deleteVaultKeep(vaultKeepId) {

  }

  async createVaultKeep(vaultKeepData) {
    await api.post('api/vaultkeeps', vaultKeepData)
    AppState.activeKeep.kept++
  }

  async getKeepsInVault(vaultId) {
    const response = await api.get(`/api/vaults/${vaultId}/keeps`)
    const keeps = response.data.map(pojo => new VaultKeepKept(pojo))
    AppState.vaultKeeps = keeps
  }

}


export const vaultKeepsService = new VaultKeepsService()