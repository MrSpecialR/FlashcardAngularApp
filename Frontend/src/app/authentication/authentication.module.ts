import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './authentication.service';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AppMaterialModule } from '../app.material.module';
import { AuthenticationRoutingModule } from './authentication.routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    AuthenticationRoutingModule,
    FormsModule
  ],
  declarations: [
    LoginComponent,
    RegisterComponent
  ],
  providers: [AuthenticationService]
})
export class AuthenticationModule { }
