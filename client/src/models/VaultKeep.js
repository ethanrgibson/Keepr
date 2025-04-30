import { DataBaseItem } from "./DataBaseItem.js";

export class VaultKeep extends DataBaseItem {

  constructor(data) {
    super(data)
    this.keepId = data.keepId
    this.vaultId = data.vaultId
    this.creatorId = data.creatorId
  }

}