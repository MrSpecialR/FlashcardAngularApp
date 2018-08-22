import { Component, OnInit } from '@angular/core';
import { DeckModel } from '../models/DeckModel';
import { DecksService } from '../decks.service';
import { Observable } from '../../../../node_modules/rxjs';

@Component({
  selector: 'app-user-decks-table',
  templateUrl: './user-decks-table.component.html',
  styleUrls: ['./user-decks-table.component.css']
})
export class UserDecksTableComponent implements OnInit {
  userDecks : Observable<DeckModel[]>;
  constructor(decksService : DecksService) { 
    this.userDecks = decksService.getUserDecks();
  }

  ngOnInit() {

  }

}
