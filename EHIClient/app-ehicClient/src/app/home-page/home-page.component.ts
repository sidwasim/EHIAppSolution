import { Component, OnInit } from '@angular/core';
import contactservice from '../shared/services/contact.service';
import contact from '../shared/models/contact';
import { PageChangeEvent } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

  constructor(private contactInfoService: contactservice) {}
  contactinfo: Array<contact>;
  public gridItems = [];
  public pageSize = 10;
  public skip = 0;
  public sortDescriptor: SortDescriptor[] = [];
  public filterTerm: number = null;
  ngOnInit() {
    // this.contactInfoService.getAll().subscribe(data => {
    //   this.contactinfo = data;
    // });
    this.loadGridItems();
  }

   


  public pageChange(event: PageChangeEvent): void {
    this.skip = event.skip;
    this.loadGridItems();
  }

  private loadGridItems(): void {
    this.contactInfoService.getAll(  ).subscribe(data => {
      this.gridItems = data;
    });
  }

  public handleSortChange(descriptor: SortDescriptor[]): void {
    this.sortDescriptor = descriptor;
    this.loadGridItems();
  }
}
