import { Component, OnInit } from '@angular/core';
import { DeckModel } from '../models/DeckModel';
import { Input } from '@angular/core';
import { DecksService } from '../decks.service';

@Component({
  selector: 'app-deck-card',
  templateUrl: './deck-card.component.html',
  styleUrls: ['./deck-card.component.css']
})
export class DeckCardComponent implements OnInit {

  @Input('deck') deck : DeckModel;

  constructor(private decksService : DecksService) { }

  ngOnInit() {
  }

  subscribe () {
    this.decksService.subscribe(this.deck.id).subscribe(_ => {
      this.deck.subscribers++;
    });
  }

  unsubscribe () {
    this.decksService.unsubscribe(this.deck.id).subscribe(_ => {
      this.deck.subscribers--;
    });
  }
}
