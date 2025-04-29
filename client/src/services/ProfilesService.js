import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class ProfilesService {


  async getProfile(profileId) {
    const response = await api.get(`/api/profiles/${profileId}`)
    logger.log(response.data)
  }

}


export const profilesService = new ProfilesService()