import { Component, OnInit } from '@angular/core';
import { LanguageModel } from '../models/LanguageModel';
import { DecksService } from '../decks.service';
import { DeckCreationModel } from '../models/DeckCreationModel';
import { LanguagesService } from '../../languages/languages.service';
import { Router } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-create-deck-form',
  templateUrl: './create-deck-form.component.html',
  styleUrls: ['./create-deck-form.component.css']
})
export class CreateDeckFormComponent implements OnInit {
  public languages : LanguageModel[];
  public bindingModel : DeckCreationModel = new DeckCreationModel('', '', '', '', '', false) ;

  constructor(private decksService : DecksService, private languagesService : LanguagesService, private router : Router) { }

  ngOnInit() {
    this.languagesService.getLanguages().subscribe(data => {
      this.languages = data;
    });
  }

  create () {
    this.decksService.create(this.bindingModel).subscribe(data => {
      this.router.navigate(['/cards/deck/' + data.id])
    });
  }
}
