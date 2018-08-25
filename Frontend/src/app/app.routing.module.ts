import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './common/home/home.component';
import { AuthenticationModule } from './authentication/authentication.module';
import { AuthenticationGuard } from './authentication/guards/authentication.guard';
import { DecksModule } from './decks/decks.module';
import { CardsModule } from './cards/cards.module';
import { StatisticsModule } from './statistics/statistics.module';
import { LanguageCreateFormComponent } from './languages/language-create-form/language-create-form.component';

const routes : Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent, canActivate: [AuthenticationGuard] },
  { path: 'user', loadChildren: () => AuthenticationModule },
  { path: 'decks', loadChildren: () => DecksModule, canActivate: [AuthenticationGuard] },
  { path: 'cards', loadChildren: () => CardsModule, canActivate: [AuthenticationGuard] },
  { path: 'statistics', loadChildren: () => StatisticsModule, canActivate: [AuthenticationGuard] },
  { path: 'languages/create', component: LanguageCreateFormComponent, canActivate: [AuthenticationGuard] }
]

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})
export class AppRoutingModule {  }