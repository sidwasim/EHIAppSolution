
import contactservice from '../shared/services/contact.service';
import { Component, OnInit, Injectable } from '@angular/core';
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
@Injectable()
export class HomePageComponent implements OnInit {

  constructor(private contactInfoService: contactservice) {}
  public gridItems = [];
  ngOnInit() {
  }

   GetSelectedData(value) {
    window.alert('This page is under development.');
  }

}
