import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeckStatisticsTableComponent } from './deck-statistics-table/deck-statistics-table.component';
import { CardStatisticsTableComponent } from './card-statistics-table/card-statistics-table.component';
import { UserStatisticsTableComponent } from './user-statistics-table/user-statistics-table.component';


const StatisticsRoutes : Routes = [
  { path: 'deck/:id', component: DeckStatisticsTableComponent },
  { path: 'card/:id', component: CardStatisticsTableComponent },
  { path: 'user/:id', component: UserStatisticsTableComponent },
  
]

@NgModule({
  imports: [
    RouterModule.forChild(StatisticsRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class StatisticsRoutingModule { }