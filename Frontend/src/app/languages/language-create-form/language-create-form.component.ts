import { Component, OnInit } from '@angular/core';
import { LanguageModel } from '../../decks/models/LanguageModel';
import { LanguagesService } from '../../decks/languages.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-language-create-form',
  templateUrl: './language-create-form.component.html',
  styleUrls: ['./language-create-form.component.css']
})
export class LanguageCreateFormComponent implements OnInit {
  bindingModel : LanguageModel = new LanguageModel();
  constructor(private languagesService : LanguagesService, private router : Router) {
  
  }

  ngOnInit() {
    this.bindingModel.code = '';
    this.bindingModel.name = '';
  }

  create () {
    this.languagesService.create(this.bindingModel).subscribe(d => {
      this.router.navigate(['/home']);
    });
  }
}
