import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardDeckDetailsComponent } from './card-deck-details/card-deck-details.component';

const CardsRoutes : Routes = [
  { path: 'deck/:id', component: CardDeckDetailsComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(CardsRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class CardsRoutingModule { }