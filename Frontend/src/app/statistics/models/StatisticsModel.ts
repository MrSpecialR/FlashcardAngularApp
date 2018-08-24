import { CardModel } from "../../cards/models/CardModel";

export class StatisticsModel {
  card: CardModel;
  accuracy: number;
  lastCheckedOn : Date;
  checkedTimes: number;
  correctTimes: number;
}