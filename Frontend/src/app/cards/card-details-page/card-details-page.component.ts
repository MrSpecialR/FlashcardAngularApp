import { Component, OnInit } from '@angular/core';
import { CardModel } from '../models/CardModel';
import { CardsService } from '../../cards.service';
import { ActivatedRoute } from '@angular/router';

import { StatisticsService } from '../../statistics/statistics.service';
import { StatisticsModel } from '../../statistics/models/StatisticsModel';


@Component({
  selector: 'app-card-details-page',
  templateUrl: './card-details-page.component.html',
  styleUrls: ['./card-details-page.component.css']
})
export class CardDetailsPageComponent implements OnInit {
  card : CardModel = new CardModel();
  id : number;
  statistics: StatisticsModel[];
  constructor(private cardsService : CardsService, route : ActivatedRoute, private statisticsService : StatisticsService) { 
    this.id = route.snapshot.params.id;
  }

  ngOnInit() {
    this.cardsService.getCardById(this.id).subscribe(card => {
      this.card = card;
      this.statisticsService.getCardStatistics(this.id).subscribe(stats => {
        debugger  
        this.statistics = stats;
      });
    });
  }

}
