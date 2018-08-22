import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardsTableComponent } from './cards-table/cards-table.component';

const CardsRoutes : Routes = [
  { path: 'deck/:id', component: CardsTableComponent }
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