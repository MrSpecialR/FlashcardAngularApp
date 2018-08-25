import { Component, OnInit } from '@angular/core';
import { StatisticsModel } from '../models/StatisticsModel';
import { StatisticsService } from '../statistics.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-statistics-table',
  templateUrl: './user-statistics-table.component.html',
  styleUrls: ['./user-statistics-table.component.css']
})
export class UserStatisticsTableComponent implements OnInit {
  statistics: StatisticsModel[];
  id : string;

  constructor(private statisticsService : StatisticsService, route : ActivatedRoute) { 
    this.id = route.snapshot.params.id;
  }

  ngOnInit() {
    this.statisticsService.getUserStatistics(this.id).subscribe(stats => {  
      this.statistics = stats;
    });
  }
}
