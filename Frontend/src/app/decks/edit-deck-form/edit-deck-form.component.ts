import { Component, OnInit } from '@angular/core';
import { LanguageModel } from '../models/LanguageModel';
import { DeckCreationModel } from '../models/DeckCreationModel';
import { DecksService } from '../decks.service';
import { LanguagesService } from '../../languages/languages.service';
import { Router, ActivatedRoute } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-edit-deck-form',
  templateUrl: './edit-deck-form.component.html',
  styleUrls: ['./edit-deck-form.component.css']
})
export class EditDeckFormComponent implements OnInit {
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
        debugger
        this.bindingModel.name = data.name;
        this.bindingModel.languageFromId = this.languages.find(l => l.name == data.languageFrom).id.toString();
        this.bindingModel.languageToId = this.languages.find(l => l.name == data.languageTo).id.toString();
        this.bindingModel.description = data.description;
        this.bindingModel.posterUrl = data['posterURL'];
        this.bindingModel.isPublic = data.isPublic;
      })
    });
  }
  edit () {
    this.decksService.edit(this.deckId, this.bindingModel).subscribe(d => {
      this.router.navigate(['/cards/deck/' + this.deckId]);
    });
  }

  compare(a, b) : boolean {
    return a == b;
  }
}

