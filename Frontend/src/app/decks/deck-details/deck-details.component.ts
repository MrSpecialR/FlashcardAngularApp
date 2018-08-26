import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DecksService } from '../decks.service';
import { DeckModel } from '../models/DeckModel';
import { AuthenticationService } from '../../authentication/authentication.service';

@Component({
  selector: 'app-deck-details',
  templateUrl: './deck-details.component.html',
  styleUrls: ['./deck-details.component.css']
})
export class DeckDetailsComponent implements OnInit {
  private id : number;
  public deck : DeckModel;

  constructor(route : ActivatedRoute, private decksService : DecksService, public auth : AuthenticationService) { 
    this.id = route.snapshot.params.id;
  }

  ngOnInit() {
    this.decksService.getById(this.id).subscribe(data => {
      this.deck = data;
    });
  }

}
