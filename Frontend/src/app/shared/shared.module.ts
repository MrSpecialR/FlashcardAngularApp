import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppMaterialModule } from '../app.material.module';

import { CardsService } from '../cards.service';
import { CardsTableComponent } from '../cards/cards-table/cards-table.component';
import { RouterModule } from '@angular/router';
import { StatisticsTableComponent } from '../statistics/statistics-table/statistics-table.component';
import { StatisticsService } from '../statistics/statistics.service';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    AppMaterialModule
  ],
  declarations: [
    CardsTableComponent,
    StatisticsTableComponent
  ],
  providers: [CardsService, StatisticsService],
  exports: [CardsTableComponent, StatisticsTableComponent]
})
export class SharedModule { }
