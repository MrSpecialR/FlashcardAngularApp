import { Component, OnInit } from '@angular/core';
import { StatisticsModel } from '../models/StatisticsModel';
import { StatisticsService } from '../statistics.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-card-statistics-table',
  templateUrl: './card-statistics-table.component.html',
  styleUrls: ['./card-statistics-table.component.css']
})
export class CardStatisticsTableComponent implements OnInit {
  statistics: StatisticsModel[];
  id : number;

  constructor(private statisticsService : StatisticsService, route : ActivatedRoute) { 
    this.id = route.snapshot.params.id;
  }

  ngOnInit() {
    this.statisticsService.getCardStatistics(this.id).subscribe(stats => {  
      this.statistics = stats;
    });
  }
}
