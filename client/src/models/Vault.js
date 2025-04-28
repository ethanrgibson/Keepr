import { Profile } from "./Account.js";
import { DataBaseItem } from "./DataBaseItem.js";

export class Vault extends DataBaseItem{

  constructor(data){
    super(data)
    this.name = data.name
    this.description = data.description
    this.imgUrl = data.img
    this.isPrivate = data.isPrivate
    this.creatorId = data.creatorId
    this.creator = new Profile(data.creator)
  }


}