export class DeckModel {
  public id : number;
  public name : string;
  public description : string;
  public posterUrl : string;
  public languageFrom : string;
  public languageTo : string;
  public creator : string;
  public subscribers : number;
  public cards : number;
  public isPublic : boolean;
  public isUserSubscribed : boolean;
}