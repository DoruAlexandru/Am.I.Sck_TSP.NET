import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';


import { HttpClientModule } from '@angular/common/http';

import {MatCardModule} from '@angular/material/card';
import {MatInputModule} from '@angular/material/input';
import {MatButtonModule} from '@angular/material/button';
import {MatRadioModule} from '@angular/material/radio';
import {MatCheckboxModule} from '@angular/material/checkbox';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './components/register/register.component';
import { QuestionnaireComponent } from './components/questionnaire/questionnaire.component';
import { MatTableModule} from '@angular/material/table';
import { HomepageComponent } from './components/homepage/homepage.component';
import { HistoryComponent } from './components/history/history.component';
import { SympFormComponent } from './components/symp-form/symp-form.component';
import { SympListComponent } from './components/symp-list/symp-list.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    QuestionnaireComponent,
    HomepageComponent,
    HistoryComponent,
    SympFormComponent,
    SympListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    HttpClientModule,
    MatRadioModule,
    MatTableModule,
    MatCheckboxModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
