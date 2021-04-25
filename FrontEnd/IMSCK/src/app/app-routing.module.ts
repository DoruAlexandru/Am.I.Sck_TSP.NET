import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HistoryComponent } from './components/history/history.component';
import { HomepageComponent } from './components/homepage/homepage.component';
import { LoginComponent } from './components/login/login.component';
import { QuestionnaireComponent } from './components/questionnaire/questionnaire.component';
import { RegisterComponent } from './components/register/register.component';
import { SympListComponent } from './components/symp-list/symp-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'homepage',
    component: HomepageComponent,
    children: [
      { path: '', redirectTo: 'symp-list', pathMatch: 'full' },
      { path: 'questionnaire', component: QuestionnaireComponent },
      { path: 'history', component: HistoryComponent },
      { path: 'symp-list',component: SympListComponent},
    ],
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
