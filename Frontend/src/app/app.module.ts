import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app.routing.module';

import { AppComponent } from './app.component';
import { MainNavigationComponent } from './common/main-navigation/main-navigation.component';
import { HomeComponent } from './common/home/home.component';

import { AppMaterialModule } from './app.material.module';
import { AuthenticationModule } from './authentication/authentication.module';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpModule } from "@angular/http";
import { JwtInterceptor } from './common/interceptors/jwt.interceptor';
import { NotificationInterceptor } from './common/interceptors/notification.interceptor';

import { NgProgressModule } from '@ngx-progressbar/core';
import { NgProgressHttpModule } from '@ngx-progressbar/http';
import { DecksModule } from './decks/decks.module';
import { LanguageCreateFormComponent } from './languages/language-create-form/language-create-form.component';
import { SharedModule } from './shared/shared.module';


@NgModule({
  declarations: [
    AppComponent,
    MainNavigationComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AppMaterialModule,
    AuthenticationModule,
    HttpClientModule,
    HttpModule,
    ToastrModule.forRoot(),
    NgProgressModule.forRoot(),
    NgProgressHttpModule,
    DecksModule,
    SharedModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: NotificationInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
