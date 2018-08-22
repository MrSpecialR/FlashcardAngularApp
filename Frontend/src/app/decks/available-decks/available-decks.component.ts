import { Component, OnInit } from '@angular/core';
import { DecksService } from '../decks.service';
import { DeckModel } from '../models/DeckModel';

@Component({
  selector: 'app-available-decks',
  templateUrl: './available-decks.component.html',
  styleUrls: ['./available-decks.component.css']
})
export class AvailableDecksComponent implements OnInit {
  decks : DeckModel[];

  constructor(private decksService : DecksService) { }

  ngOnInit() {
    this.decksService.getAvailableDecks().subscribe(data => {
      this.decks = data;
    });
  }

}
