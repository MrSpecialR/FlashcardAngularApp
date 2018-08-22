import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BASE_URL } from './common/constants';
import { CardModel } from './cards/models/CardModel';



const CARDS_BASE_URL : string = BASE_URL + '/cards/';


@Injectable()
export class CardsService {
  constructor (private http: HttpClient) {
   }

   getDeckCards(deckId : number) : Observable<CardModel[]> {
     return this.http.get<CardModel[]>(CARDS_BASE_URL + 'deck/' + deckId)
   }
   
   createCard (card : CardModel, deckId : number) {
     return this.http.post(CARDS_BASE_URL + 'create/' + deckId, card);
   }
}
