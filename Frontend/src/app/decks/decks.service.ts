import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BASE_URL } from '../common/constants';
import { DeckCreationModel } from './models/DeckCreationModel';
import { DeckModel } from './models/DeckModel';
import { IIdentifiable } from '../common/interfaces/IIdentifiable';



const DECKS_BASE_URL : string = BASE_URL + '/decks/';


@Injectable()
export class DecksService {
  constructor (private http: HttpClient) {
   }

   create (deck : DeckCreationModel) :Observable<IIdentifiable> {
     return this.http.post<IIdentifiable>(DECKS_BASE_URL + 'create', deck);
   }

   getUserDecks() : Observable<DeckModel[]> {
     return this.http.get<DeckModel[]>(DECKS_BASE_URL + 'userdecks');
   }

   getUserSubscriptionDecks()  : Observable<DeckModel[]> {
    return this.http.get<DeckModel[]>(DECKS_BASE_URL + 'usersubscriptions');
  }

  getAvailableDecks() : Observable<DeckModel[]> {
    return this.http.get<DeckModel[]>(DECKS_BASE_URL + 'available');
  }

  subscribe(deckId : number) {
    return this.http.post(DECKS_BASE_URL + 'subscribe/' + deckId, {});
  }

  unsubscribe(deckId : number) {
    return this.http.post(DECKS_BASE_URL + 'unsubscribe/' + deckId, {});
  }

  getById(deckId : number) : Observable<DeckModel> {
    return this.http.get<DeckModel>(DECKS_BASE_URL + '/details/' + deckId);
  }

  edit (deckId : number, model : DeckCreationModel) {
    return this.http.put(DECKS_BASE_URL + 'edit/' + deckId, model);
  }

  delete (deckId : number) {
    return this.http.delete(DECKS_BASE_URL + 'delete/' + deckId);
  }
}
