import { Component, OnInit } from '@angular/core';
import { DecksService } from '../decks.service';
import { LanguagesService } from '../languages.service';
import { Router, ActivatedRoute } from '@angular/router';
import { DeckCreationModel } from '../models/DeckCreationModel';
import { LanguageModel } from '../models/LanguageModel';

@Component({
  selector: 'app-delete-deck-form',
  templateUrl: './delete-deck-form.component.html',
  styleUrls: ['./delete-deck-form.component.css']
})
export class DeleteDeckFormComponent implements OnInit {

  private deckId : number;
  public languages : LanguageModel[];
  public bindingModel : DeckCreationModel = new DeckCreationModel('', '', '', '', '', false) ;

  constructor(
    private decksService : DecksService,
    private languagesService : LanguagesService,
    private router : Router,
    private route : ActivatedRoute) {
        let deckId : number = this.route.snapshot.params.id;
        this.deckId = deckId;
   }

  ngOnInit() {
    this.languagesService.getLanguages().subscribe(data => {
      this.languages = data;
      this.decksService.getById(this.deckId).subscribe(data => {
        this.bindingModel.name = data.name;
        this.bindingModel.languageFromId = this.languages.find(l => l.name == data.languageFrom).id.toString();
        this.bindingModel.languageToId = this.languages.find(l => l.name == data.languageTo).id.toString();
        this.bindingModel.description = data.description;
        this.bindingModel.posterUrl = data['posterURL'];
        this.bindingModel.isPublic = data.isPublic;
      })
    });
  }

  compare(a, b) : boolean {
    return a == b;
  }

  delete () {
    this.decksService.delete(this.deckId).subscribe(_ => {

    });
  }
}
