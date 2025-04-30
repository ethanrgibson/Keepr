import { DataBaseItem } from "./DataBaseItem.js";
import { Keep } from "./Keep.js";

export class VaultKeep extends DataBaseItem {

  constructor(data) {
    super(data)
    this.keepId = data.keepId
    this.vaultId = data.vaultId
    this.creatorId = data.creatorId
  }

}


export class VaultKeepKept extends Keep{
  constructor(data){
    super(data)
    this.vaultKeepId = data.vaultKeepId
    this.creatorId = data.creatorId
  }
}