import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {
  async createVault(vaultData) {
    const response = await api.post('api/vaults', vaultData)
    logger.log(response.data)
  }

}



export const vaultsService = new VaultsService()