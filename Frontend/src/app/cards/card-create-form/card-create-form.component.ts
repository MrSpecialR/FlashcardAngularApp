import { Component, OnInit } from '@angular/core';
import { CardModel } from '../models/CardModel';
import { CardsService } from '../cards.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-card-create-form',
  templateUrl: './card-create-form.component.html',
  styleUrls: ['./card-create-form.component.css']
})
export class CardCreateFormComponent implements OnInit {
  bindingModel : CardModel = new CardModel();
  deckId : number;

  constructor(private cardsService : CardsService, route : ActivatedRoute, private router : Router) {
    this.deckId = route.snapshot.params.id;
   }

  ngOnInit() {
  }

  create () {
    this.cardsService.createCard(this.bindingModel, this.deckId).subscribe(_ => {
      this.router.navigate(['/cards/deck/' + this.deckId]);
    })
  }
}
