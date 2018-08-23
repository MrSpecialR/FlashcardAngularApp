import { Component, OnInit, ViewChild, Input } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { CardsTableDataSource } from './cards-table-datasource';
import { CardsService } from '../../cards.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';
import { CardModel } from '../models/CardModel';
import { NgModel, NgForm } from '../../../../node_modules/@angular/forms';
import { AuthenticationService } from '../../authentication/authentication.service';

@Component({
  selector: 'app-cards-table',
  templateUrl: './cards-table.component.html',
  styleUrls: ['./cards-table.component.css']
})
export class CardsTableComponent implements OnInit {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  dataSource: CardsTableDataSource;
  data : CardModel[] = [];
  displayedColumns = ['index', 'word', 'translation', 'hint', 'imageUrl', 'actions'];
  @Input('isCreator') isCreator : boolean;

  bindingModel : CardModel = new CardModel();
  deckid : number;


  constructor (private cardsService : CardsService, private route : ActivatedRoute, public auth : AuthenticationService ) {}

  ngOnInit() {
    this.dataSource = new CardsTableDataSource(this.paginator, this.sort, []);
    let deckId : number = this.route.snapshot.params.id;
    this.deckid = deckId;
    this.cardsService.getDeckCards(deckId).subscribe(data => {
      data = data.map((d, i) => {
        d['index'] = i + 1;
        return d;
      });
      this.data = data;
      this.dataSource = new CardsTableDataSource(this.paginator, this.sort, this.data);
    })
  }

  add (form : NgForm) {
    this.cardsService.createCard(this.bindingModel, this.deckid).subscribe(_ => {
      this.bindingModel['index'] = this.data.length + 1;
      this.data.push(Object.assign(new CardModel(), this.bindingModel));
      this.dataSource = new CardsTableDataSource(this.paginator, this.sort, this.data);
      form.resetForm(new CardModel());
    });
  }
}
