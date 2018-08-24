import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppMaterialModule } from '../app.material.module';
import { CardsService } from '../cards.service';
import { CardsRoutingModule } from './cards.routing.module';
import { CardDeckDetailsComponent } from './card-deck-details/card-deck-details.component';
import { SharedModule } from '../shared/shared.module';
import { CardDetailsComponent } from './card-details/card-details.component';
import { StatisticsService } from '../statistics/statistics.service';
import { CardDetailsPageComponent } from './card-details-page/card-details-page.component';
import { CardEditFormComponent } from './card-edit-form/card-edit-form.component';
import { CardDeleteFormComponent } from './card-delete-form/card-delete-form.component';
import { CardCreateFormComponent } from './card-create-form/card-create-form.component';


@NgModule({
  imports: [
    CommonModule,
    CardsRoutingModule,
    FormsModule,
    AppMaterialModule,
    SharedModule
  ],
  declarations: [
    CardDeckDetailsComponent,
    CardDetailsComponent,
    CardDetailsPageComponent,
    CardCreateFormComponent,
    CardEditFormComponent,
    CardDeleteFormComponent
  ],
  providers: [CardsService, StatisticsService]
})
export class CardsModule { }
