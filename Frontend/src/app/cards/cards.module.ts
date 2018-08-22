import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppMaterialModule } from '../app.material.module';
import { CardsService } from '../cards.service';
import { CardsRoutingModule } from './cards.routing.module';
import { CardsTableComponent } from './cards-table/cards-table.component';


@NgModule({
  imports: [
    CommonModule,
    CardsRoutingModule,
    FormsModule,
    AppMaterialModule
  ],
  declarations: [
    CardsTableComponent
  ],
  providers: [CardsService]
})
export class CardsModule { }
