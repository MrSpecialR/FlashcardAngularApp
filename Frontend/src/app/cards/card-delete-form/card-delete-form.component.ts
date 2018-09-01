import { Component, OnInit } from '@angular/core';
import { CardsService } from '../cards.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CardModel } from '../models/CardModel';
import { Route } from '@angular/compiler/src/core';

@Component({
  selector: 'app-card-delete-form',
  templateUrl: './card-delete-form.component.html',
  styleUrls: ['./card-delete-form.component.css']
})
export class CardDeleteFormComponent implements OnInit {
  bindingModel : CardModel;
  id : number;

  constructor(private cardsService : CardsService, route : ActivatedRoute, private router : Router) {
    this.id = route.snapshot.params.id;
   }

  ngOnInit() {
    this.cardsService.getCardById(this.id).subscribe(card => {
      this.bindingModel = card;
    })
  }

  delete () {
    this.cardsService.deleteCard(this.id).subscribe(data => {

      this.router.navigate(['/decks/details/' + data['id'] ]);
    });
  }

}
