import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Account, Profile } from "@/models/Account.js"

class ProfilesService {


  async getProfile(profileId) {
    const response = await api.get(`/api/profiles/${profileId}`)
    AppState.activeProfile = new Profile(response.data)
  }

}


export const profilesService = new ProfilesService()