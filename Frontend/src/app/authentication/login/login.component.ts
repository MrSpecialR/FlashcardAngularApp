import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../models/LoginModel';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public bindingModel : LoginModel = new LoginModel('', '');
  constructor(private authService : AuthenticationService, private router : Router) { }

  ngOnInit() {
  }

  login () {
    this.authService.login(this.bindingModel).subscribe(data => {
      this.router.navigate(['/home']);
    });
  }

  print (val) {
    console.log(val);
  }
}
