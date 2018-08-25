import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BASE_URL } from '../common/constants';
import { StatisticsModel } from './models/StatisticsModel';
import { UploadStatisticsModel } from '../decks/models/UploadStatisticsModel';

const STATISTICS_BASE_URL = BASE_URL + '/statistics/';

@Injectable()
export class StatisticsService {
  constructor (private http: HttpClient) {  }

  uploadStatistics(data : UploadStatisticsModel[]) {
    return this.http.post(STATISTICS_BASE_URL + 'upload' , data); 
  }

  getDeckStatistics(deckId : number) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(STATISTICS_BASE_URL + 'deck/' + deckId);
  }

  getCardStatistics(cardId : number) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(STATISTICS_BASE_URL + 'card/' + cardId);
  }

  getUserStatistics(userId : string) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(STATISTICS_BASE_URL + 'user/' + userId);
  }

  getUserDeckStatistics(deckId : number, userId : string) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(STATISTICS_BASE_URL + 'user/' + userId);
  }

  getUserDeckCardStatistics(cardId: number, deckId : number, userId : string) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(BASE_URL + '' + userId);
  }
}
