import { Component, OnInit } from '@angular/core';
import { CardsService } from '../../cards.service';
import { ActivatedRoute } from '@angular/router';
import { CardModel } from '../models/CardModel';

@Component({
  selector: 'app-card-delete-form',
  templateUrl: './card-delete-form.component.html',
  styleUrls: ['./card-delete-form.component.css']
})
export class CardDeleteFormComponent implements OnInit {
  bindingModel : CardModel;
  id : number;

  constructor(private cardsService : CardsService, route : ActivatedRoute) {
    this.id = route.snapshot.params.id;
   }

  ngOnInit() {
    this.cardsService.getCardById(this.id).subscribe(card => {
      this.bindingModel = card;
    })
  }

}
