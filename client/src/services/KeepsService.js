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

  async setActiveKeep(keepId) {
    AppState.activeKeep = null
    const response = await api.get(`api/keeps/${keepId}`)
    const keep = new Keep(response.data)
    AppState.activeKeep = keep
  }

  async createKeep(createdKeepData) {
    const response = await api.post('api/keeps', createdKeepData)
    const keep = new Keep(response.data)
    AppState.keeps.unshift(keep)
  }

  async deleteKeep(keep) {
    const response = await api.delete(`api/keeps/${keep.id}`)
    const keeps = AppState.keeps
    const keepIndex = keeps.findIndex(keep => keep.id == keep.id)
    keeps.splice(keepIndex, 1)
    logger.log(response.data)
  }
 
}

export const keepsService = new KeepsService()