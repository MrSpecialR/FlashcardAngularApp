import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CardDeckDetailsComponent } from './card-deck-details/card-deck-details.component';
import { CardDetailsPageComponent } from './card-details-page/card-details-page.component';
import { CardEditFormComponent } from './card-edit-form/card-edit-form.component';
import { CardDeleteFormComponent } from './card-delete-form/card-delete-form.component';
import { CardCreateFormComponent } from './card-create-form/card-create-form.component';

const CardsRoutes : Routes = [
  { path: 'deck/:id', component: CardDeckDetailsComponent },
  { path: 'details/:id', component: CardDetailsPageComponent },
  { path: 'create/:id', component: CardCreateFormComponent },
  { path: 'edit/:id', component: CardEditFormComponent },
  { path: 'delete/:id', component: CardDeleteFormComponent }
  
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