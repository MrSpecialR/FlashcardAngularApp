import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppMaterialModule } from '../app.material.module';

import { RouterModule } from '@angular/router';
import { StatisticsService } from './statistics.service';
import { SharedModule } from '../shared/shared.module';
import { DeckStatisticsTableComponent } from './deck-statistics-table/deck-statistics-table.component';
import { UserStatisticsTableComponent } from './user-statistics-table/user-statistics-table.component';
import { CardStatisticsTableComponent } from './card-statistics-table/card-statistics-table.component';
import { StatisticsRoutingModule } from './statistics.routing.module';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    AppMaterialModule,
    SharedModule,
    StatisticsRoutingModule
  ],
  declarations: [
    DeckStatisticsTableComponent,
    UserStatisticsTableComponent,
    CardStatisticsTableComponent

  ],
  providers: [StatisticsService]
})
export class StatisticsModule { }
