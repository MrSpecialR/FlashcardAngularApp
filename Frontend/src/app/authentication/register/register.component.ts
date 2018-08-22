import { Component, OnInit } from '@angular/core';
import { RegisterModel } from '../models/RegisterModel';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public bindingModel : RegisterModel = new RegisterModel('', '', '', '');
  constructor (private auth : AuthenticationService, private router : Router) {}
  ngOnInit() {

  }

  register () {
    this.auth.register(this.bindingModel).subscribe(data => {
      this.router.navigate(['/home']);
    });
  }
}
