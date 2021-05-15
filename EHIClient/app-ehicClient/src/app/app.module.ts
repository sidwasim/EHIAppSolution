import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';

import { HttpClientModule } from '@angular/common/http';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ContactInfoComponent } from '../app/contact-info/contact-info.component';
// import { SugarLevelEditComponent } from './sugarlevel-edit/sugarlevel-edit.component';
import contactservice from './shared/services/contact.service';
import { GridModule } from '@progress/kendo-angular-grid';
import { GridDataResult, PageChangeEvent } from '@progress/kendo-angular-grid';
import { HomePageComponent } from './home-page/home-page.component';
import { MessagesComponent } from './messages/messages.component';
import { ContactNewComponent } from './contact-new/contact-new.component';

const appRoutes: Routes = [
  { path: '', redirectTo: '/contact-info', pathMatch: 'full' },
  {
    path: 'contact-info',
    component: ContactInfoComponent
  },
  {
    path: 'sugarlevel-add',
    component: ContactInfoComponent
  },
  {
    path: 'sugarlevel-edit/:id',
    component: ContactInfoComponent
  }
];

const routes: Routes = [
  { path: '', redirectTo: '/homepage', pathMatch: 'full' },
  { path: 'homepage', component: HomePageComponent },
  { path: 'contacts/:id', component: ContactInfoComponent },
  { path: 'contacts', component: ContactInfoComponent },
  { path: 'contact-new', component: ContactNewComponent },
];

@NgModule({
  declarations: [
    AppComponent,
    ContactInfoComponent,
    HomePageComponent,
    MessagesComponent,
    ContactNewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    GridModule,
    
    BrowserAnimationsModule,
    FormsModule,
    RouterModule.forRoot(routes),
    GridModule,
  ],
  providers: [contactservice],
  bootstrap: [AppComponent]
})
export class AppModule { }
