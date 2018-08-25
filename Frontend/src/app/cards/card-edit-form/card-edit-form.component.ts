import { Component, OnInit } from '@angular/core';
import { CardModel } from '../models/CardModel';
import { CardsService } from '../../cards.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-card-edit-form',
  templateUrl: './card-edit-form.component.html',
  styleUrls: ['./card-edit-form.component.css']
})
export class CardEditFormComponent implements OnInit {
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

  edit () {
    this.cardsService.edit(this.id, this.bindingModel).subscribe(data => {
      this.router.navigate(['/decks/details/' + data['id'] ]);
    });
  }
}
