import { Component, OnInit } from '@angular/core';
import { DecksService } from '../decks.service';
import { DeckModel } from '../models/DeckModel';
import { Observable } from '../../../../node_modules/rxjs';

@Component({
  selector: 'app-user-subscribtion-decks-table',
  templateUrl: './user-subscribtion-decks-table.component.html',
  styleUrls: ['./user-subscribtion-decks-table.component.css']
})
export class UserSubscribtionDecksTableComponent implements OnInit {
  userDecks : Observable<DeckModel[]>;


  constructor(decksService : DecksService) { 
    this.userDecks = decksService.getUserSubscriptionDecks();
  }

  ngOnInit() {
  }

}
