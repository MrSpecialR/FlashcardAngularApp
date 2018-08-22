import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { DeckTableDataSource } from './deck-table-datasource';
import { DeckModel } from '../models/DeckModel';
import { Observable } from '../../../../node_modules/rxjs';

@Component({
  selector: 'app-deck-table',
  templateUrl: './deck-table.component.html',
  styleUrls: ['./deck-table.component.css']
})
export class DeckTableComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: DeckTableDataSource;

  @Input('title') title : string;

  @Input('userData') userData : Observable<DeckModel[]>;
  @Input('hideCreator') creator : boolean;
  @Input('hideSubscribers') subscribers : boolean;

  @Input('url') url : string;

  constructor () {
  }

  /** Columns displayed in the table. Columns IDs can be added, removed, or reordered. */
  displayedColumns = ['index', 'name', 'languageTo','languageFrom', 'creator', 'cards', 'subscribers'];

  ngOnInit() {
    this.dataSource = new DeckTableDataSource(this.paginator, this.sort, []);
    if (this.creator) {
      this.displayedColumns = this.displayedColumns.filter(c => c !== 'creator');
    }

    if (this.subscribers) {
      this.displayedColumns = this.displayedColumns.filter(c => c !== 'subscribers');
    }
    
    this.userData.subscribe(data => {
      data = data.map((d, i) => {
        d['index'] = i + 1;
        return d;
      })
      this.dataSource = new DeckTableDataSource(this.paginator, this.sort, data);
    })
  }
}
