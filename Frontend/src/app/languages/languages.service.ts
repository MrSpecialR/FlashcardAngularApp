import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LanguageModel } from '../decks/models/LanguageModel';
import { Observable } from 'rxjs';
import { BASE_URL } from '../common/constants';



const LANGUAGES_BASE_URL : string = BASE_URL + '/languages/';


@Injectable()
export class LanguagesService {
  constructor (private http: HttpClient) {
   }

   getLanguages () : Observable<LanguageModel[]> {
     return this.http.get<LanguageModel[]>(LANGUAGES_BASE_URL + 'all');
   }

   create (language : LanguageModel) {
    return this.http.post(LANGUAGES_BASE_URL + 'create', language);
   }

}
