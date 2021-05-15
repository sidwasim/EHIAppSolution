import { Component, OnInit,Input } from '@angular/core';
import contactservice from '../shared/services/contact.service';
import contact from '../shared/models/contact';
import { PageChangeEvent } from '@progress/kendo-angular-grid';
import { SortDescriptor } from '@progress/kendo-data-query';
import { Observable } from 'rxjs';
import { Router} from '@angular/router';
@Component({
  selector: 'app-contact-info',
  templateUrl: './contact-info.component.html',
  styleUrls: ['./contact-info.component.css']
})
export class ContactInfoComponent implements OnInit {

  contactinfo: Array<contact>;
  public gridItems = [];
  public pageSize = 5;
  public skip = 0;
  public sortDescriptor: SortDescriptor[] = [];
  public filterTerm: number = null;
  appcontactnew: contact;
  abc: any;
  constructor(private contactInfoService: contactservice, private router: Router) {}

  ngOnInit() {
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

   updateContactInfo(dataItem): void {
      this.appcontactnew = {
              id : dataItem.Id,
              firstName : dataItem.FirstName,
              lastName : dataItem.LastName,
              isActive : dataItem.IsActive,
              email : dataItem.Email,
              phoneNumber : dataItem.PhoneNumber
            };
      this.contactInfoService.setData(this.appcontactnew);
      this.router.navigate(['/contact-new'], { queryParams: {q: 'folder'} });
  }
  
  markInActive = (dataItem) => {
    const request = {
    firstName : '',
    lastName : '',
    email : '',
    phoneNumber : '',
    isActive: !dataItem.IsActive,
    id: dataItem.Id
    };
    this.contactInfoService.save(request).subscribe(obj => {
      let response = obj;
      this.loadGridItems();
    });
  }

  deletedata = (model) => {
      this.contactInfoService.remove(model.Id).subscribe(obj => {
        let response = obj;
        this.loadGridItems();
      });
  }
}
