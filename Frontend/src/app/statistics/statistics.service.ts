import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { BASE_URL } from '../common/constants';
import { StatisticsModel } from './models/StatisticsModel';

const STATISTICS_BASE_URL = BASE_URL + '/statistics/';

@Injectable()
export class StatisticsService {
  constructor (private http: HttpClient) {  }

  uploadStatistic() {

  }

  getDeckStatistics(deckId : number) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(BASE_URL + '' + deckId);
  }

  getCardStatistics(cardId : number) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(STATISTICS_BASE_URL + 'card/' + cardId);
  }

  getUserStatistics(userId : string) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(BASE_URL + '' + userId);
  }

  getUserDeckStatistics(deckId : number, userId : string) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(BASE_URL + '' + userId);
  }

  getUserDeckCardStatistics(cardId: number, deckId : number, userId : string) : Observable<StatisticsModel[]> {
    return this.http.get<StatisticsModel[]>(BASE_URL + '' + userId);
  }
}
