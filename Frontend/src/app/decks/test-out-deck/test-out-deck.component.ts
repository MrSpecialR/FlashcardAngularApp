import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { CardModel } from '../../cards/models/CardModel';
import { StatisticsService } from '../../statistics/statistics.service';
import { CardsService } from '../../cards.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material';
import { UploadStatisticsModel } from '../models/UploadStatisticsModel';
import { StatisticsModel } from '../../statistics/models/StatisticsModel';

@Component({
  selector: 'app-test-out-deck',
  templateUrl: './test-out-deck.component.html',
  styleUrls: ['./test-out-deck.component.css'],
  encapsulation: ViewEncapsulation.None

})
export class TestOutDeckComponent implements OnInit {
  public words : CardModel[];
  public results : UploadStatisticsModel[] = [];

  public dbResults : StatisticsModel[];

  public translation : string;
  id : number;
  result : object;
  public index = 0;

  constructor(private statisticsService : StatisticsService, private cardsService : CardsService, route : ActivatedRoute, public snackBar : MatSnackBar, private router : Router) { 
    this.id = route.snapshot.params.id;
  }

  get progress () : number {
    return (100 * (this.index) / (this.words.length - 1));
  }

  ngOnInit() {
    this.cardsService.getDeckCards(this.id).subscribe(d => {
      this.words = d;
      this.shuffle(0);
    })
  }

  check(form : NgForm) {
    let isCorrect = this.areEqual(this.translation, this.words[this.index].translation)
    this.results.push(
      new UploadStatisticsModel(this.id, this.words[this.index].id, isCorrect, this.words[this.index].word)
    );

    if (isCorrect) {
      this.snackBar.open('Correct!', 'Close');
      if (this.words.length - 1 === this.index) {
        this.statisticsService.uploadStatistics(this.results).subscribe(data => {
          this.dbResults = data.results;
          this.snackBar.dismiss();
        })
      } else {
        this.index++;
      }
    } else {
      this.words.push(this.words[this.index]);
      this.shuffle(this.index);
      this.snackBar.dismiss();
      this.snackBar.open('Incorrect: Translation was ' + this.words[this.index].translation, 'Close');
    }
    form.resetForm();
  }

  areEqual(value : string, expected : string) : boolean {
    if (value == null) {
      return false;
    }
    value = value.toLocaleLowerCase();
    return value.localeCompare(expected.toLocaleLowerCase()) == 0;
  }

  shuffle (start: number, end? : number) {
    if (!end) {
      end = this.words.length;
    }
    for (let i = start; i < end; ++i) {
          let indexToSwap = Math.floor(Math.random() * Math.floor(end - i - 1));
          let temp = this.words[indexToSwap];
          this.words[indexToSwap] = this.words[end - i - 1];
          this.words[end - i - 1] = temp;
    }
  }
}