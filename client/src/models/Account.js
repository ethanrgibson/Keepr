export class Profile {
  constructor(data) {
    this.id = data.id
    this.picture = data.picture
    this.name = data.name
    this.coverImg = data.coverImg
  }
}

export class Account extends Profile {
  /**
   * @typedef AccountData
   * @property {string} id
   * @property {string} email
   * @property {string} name
   * @property {string} picture
   * 
   * @param {AccountData} data
   */
  constructor(data) {
    super(data)
    this.email = data.email
    // TODO add additional properties if needed
  }
}
