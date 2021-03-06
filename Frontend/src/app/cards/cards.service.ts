import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BASE_URL } from '../common/constants';
import { CardModel } from './models/CardModel';
import { IIdentifiable } from '../common/interfaces/IIdentifiable';

const CARDS_BASE_URL : string = BASE_URL + '/cards/';


@Injectable()
export class CardsService {
  constructor (private http: HttpClient) {
   }

   getDeckCards(deckId : number) : Observable<CardModel[]> {
     return this.http.get<CardModel[]>(CARDS_BASE_URL + 'deck/' + deckId)
   }
   
   createCard (card : CardModel, deckId : number) : Observable<IIdentifiable> {
     return this.http.post<IIdentifiable>(CARDS_BASE_URL + 'create/' + deckId, card);
   }

   getCardById(cardId : number) : Observable<CardModel> {
      return this.http.get<CardModel>(CARDS_BASE_URL + 'details/' + cardId); 
   }

   deleteCard(cardId : number) {
     return this.http.delete(CARDS_BASE_URL + 'delete/' + cardId);
   }

   edit (cardId : number, model : CardModel) {
    return this.http.put(CARDS_BASE_URL + 'edit/' + cardId, model);
  }

}
