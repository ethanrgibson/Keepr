import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Keep } from "@/models/Keep.js"
import { AppState } from "@/AppState.js"

class KeepsService {
  async getAllKeeps() {
    const response = await api.get('api/keeps')
    const keeps = response.data.map(pojo => new Keep(pojo))
    AppState.keeps = keeps

  }

  async setActiveKeep(keep) {
    const response = await api.get(`api/keeps/${keep.id}`)
    logger.log(response.data)
  }

}

export const keepsService = new KeepsService()