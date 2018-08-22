import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { DecksService } from './decks.service';
import { DecksRoutingModule } from './decks.routing.module';
import { CreateDeckFormComponent } from './create-deck-form/create-deck-form.component';
import { AppMaterialModule } from '../app.material.module';
import { LanguagesService } from './languages.service';
import { DeckTableComponent } from './deck-table/deck-table.component';
import { UserDecksTableComponent } from './user-decks-table/user-decks-table.component';
import { UserSubscribtionDecksTableComponent } from './user-subscribtion-decks-table/user-subscribtion-decks-table.component';
import { DeckCardComponent } from './deck-card/deck-card.component';
import { AvailableDecksComponent } from './available-decks/available-decks.component';
import { EditDeckFormComponent } from './edit-deck-form/edit-deck-form.component';


@NgModule({
  imports: [
    CommonModule,
    DecksRoutingModule,
    FormsModule,
    AppMaterialModule
  ],
  declarations: [
    CreateDeckFormComponent,
    DeckTableComponent,
    UserDecksTableComponent,
    UserSubscribtionDecksTableComponent,
    DeckCardComponent,
    AvailableDecksComponent,
    EditDeckFormComponent
  ],
  providers: [DecksService, LanguagesService]
})
export class DecksModule { }
