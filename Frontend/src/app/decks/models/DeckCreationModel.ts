export class DeckCreationModel {
  constructor (
  public name : string,
  public description : string,
  public posterUrl : string,
  public languageFromId : string,
  public languageToId : string,
  public isPublic : boolean
  ) {}
}
