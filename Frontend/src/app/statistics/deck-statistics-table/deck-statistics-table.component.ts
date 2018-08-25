import { Component, OnInit } from '@angular/core';
import { StatisticsService } from '../statistics.service';
import { ActivatedRoute } from '@angular/router';
import { StatisticsModel } from '../models/StatisticsModel';

@Component({
  selector: 'app-deck-statistics-table',
  templateUrl: './deck-statistics-table.component.html',
  styleUrls: ['./deck-statistics-table.component.css']
})
export class DeckStatisticsTableComponent implements OnInit {
  statistics: StatisticsModel[];
  id : number;

  constructor(private statisticsService : StatisticsService, route : ActivatedRoute) { 
    this.id = route.snapshot.params.id;
  }

  ngOnInit() {
    this.statisticsService.getDeckStatistics(this.id).subscribe(stats => {  
      this.statistics = stats;
    });
  }

}
