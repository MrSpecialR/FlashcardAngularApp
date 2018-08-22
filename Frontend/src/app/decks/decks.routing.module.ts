import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CreateDeckFormComponent } from './create-deck-form/create-deck-form.component';
import { UserDecksTableComponent } from './user-decks-table/user-decks-table.component';
import { UserSubscribtionDecksTableComponent } from './user-subscribtion-decks-table/user-subscribtion-decks-table.component';
import { AvailableDecksComponent } from './available-decks/available-decks.component';
import { EditDeckFormComponent } from './edit-deck-form/edit-deck-form.component';



const DecksRoutes : Routes = [
  { path: 'create', component: CreateDeckFormComponent },
  { path: 'all', component: UserDecksTableComponent },
  { path: 'subscriptions', component: UserSubscribtionDecksTableComponent },
  { path: 'available', component: AvailableDecksComponent },
  { path: 'edit/:id', component: EditDeckFormComponent }
  
]

@NgModule({
  imports: [
    RouterModule.forChild(DecksRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class DecksRoutingModule { }