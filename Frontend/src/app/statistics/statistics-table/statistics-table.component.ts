import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { StatisticsModel } from '../models/StatisticsModel';
import { MatSort, MatPaginator } from '@angular/material';
import { StatisticsTableDataSource } from './statistics-table-datasource';

@Component({
  selector: 'app-statistics-table',
  templateUrl: './statistics-table.component.html',
  styleUrls: ['./statistics-table.component.css']
})
export class StatisticsTableComponent implements OnInit { 
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: StatisticsTableDataSource;

  @Input('title') title : string;

  @Input('data') data : StatisticsModel[] = [];

  @Input('hideUser') user : boolean;
  @Input('hideWord') word : boolean;

  displayedColumns = ['word', 'user', 'accuracy',  'correct', 'checked'];

  ngOnInit() {
    if (this.user) {
      this.displayedColumns = this.displayedColumns.filter(dc => dc !== 'user');
    }

    if (this.word) {
      this.displayedColumns = this.displayedColumns.filter(dc => dc !== 'word');
    }
    

    this.dataSource = new StatisticsTableDataSource(this.paginator, this.sort, this.data);
  }

}
