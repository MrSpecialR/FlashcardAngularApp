import { Component, OnInit } from '@angular/core';
import { DeckModel } from '../models/DeckModel';
import { Input } from '@angular/core';
import { DecksService } from '../decks.service';
import { AuthenticationService } from '../../authentication/authentication.service';

@Component({
  selector: 'app-deck-card',
  templateUrl: './deck-card.component.html',
  styleUrls: ['./deck-card.component.css']
})
export class DeckCardComponent implements OnInit {

  @Input('deck') deck : DeckModel;

  @Input('isCreator') isCreator : boolean;

  constructor(private decksService : DecksService, public auth : AuthenticationService) { }

  ngOnInit() {
  }

  subscribe () {
    this.decksService.subscribe(this.deck.id).subscribe(_ => {
      this.deck.subscribers++;
      this.deck.isUserSubscribed = true;
    });
  }

  unsubscribe () {
    this.decksService.unsubscribe(this.deck.id).subscribe(_ => {
      this.deck.subscribers--;
      this.deck.isUserSubscribed = false;
    });
  }
}
