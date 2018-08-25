export class UploadStatisticsModel {
  constructor (
  public deckId : number,
  public cardid : number,
  public isSuccessful : boolean,
  public cardName : string
  ) {}
}
