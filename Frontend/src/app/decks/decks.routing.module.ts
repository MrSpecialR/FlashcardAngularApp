import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CreateDeckFormComponent } from './create-deck-form/create-deck-form.component';
import { UserDecksTableComponent } from './user-decks-table/user-decks-table.component';
import { UserSubscribtionDecksTableComponent } from './user-subscribtion-decks-table/user-subscribtion-decks-table.component';
import { AvailableDecksComponent } from './available-decks/available-decks.component';
import { EditDeckFormComponent } from './edit-deck-form/edit-deck-form.component';
import { DeleteDeckFormComponent } from './delete-deck-form/delete-deck-form.component';
import { DeckDetailsComponent } from './deck-details/deck-details.component';
import { TestOutDeckComponent } from './test-out-deck/test-out-deck.component';



const DecksRoutes : Routes = [
  { path: 'create', component: CreateDeckFormComponent },
  { path: 'all', component: UserDecksTableComponent },
  { path: 'subscriptions', component: UserSubscribtionDecksTableComponent },
  { path: 'available', component: AvailableDecksComponent },
  { path: 'edit/:id', component: EditDeckFormComponent },
  { path: 'delete/:id', component: DeleteDeckFormComponent },
  { path: 'details/:id', component: DeckDetailsComponent },
  { path: 'test-out/:id', component: TestOutDeckComponent }
  
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