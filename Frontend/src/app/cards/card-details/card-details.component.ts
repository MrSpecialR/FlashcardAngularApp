import { Component, OnInit, Input } from '@angular/core';
import { CardModel } from '../models/CardModel';
import { AuthenticationService } from '../../authentication/authentication.service';

@Component({
  selector: 'app-card-details',
  templateUrl: './card-details.component.html',
  styleUrls: ['./card-details.component.css']
})
export class CardDetailsComponent implements OnInit {
  @Input('card') card : CardModel;

  @Input('isCreator') isCreator : boolean;

  constructor(public auth : AuthenticationService) { }

  ngOnInit() {
    
  }

}
