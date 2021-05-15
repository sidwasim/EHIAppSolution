import { Component, OnInit , Input} from '@angular/core';
import contact from '../shared/models/contact';
import contactservice from '../shared/services/contact.service';
import { Router, ActivatedRoute} from '@angular/router';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-contact-new',
  templateUrl: './contact-new.component.html',
  styleUrls: ['./contact-new.component.css']
})
export class ContactNewComponent implements OnInit {

  constructor(private contactInfoService: contactservice, private route: ActivatedRoute) { }
  submitted = false;
  btnName = 'ADD Employee';
model = new contact();
  ngOnInit() {
    const data =  this.contactInfoService.getData();
    if (data != null && data.id > 0)
    {
      this.btnName = 'UPDATE Employee';
      this.model = data;
    }
    else {
    this.btnName = 'ADD Employee';
    }
  }

  // tslint:disable-next-line:use-life-cycle-interface
  ngOnDestroy() {
     // tslint:disable-next-line:new-parens
     this.contactInfoService.setData(new contact);
  }


  onSubmit() {
    this.saveContactInfo();
    this.submitted = true;
  }

  newHero() {
    this.model = new contact();
  }

  private saveContactInfo(): void {
    const request = {
    firstName : this.model.firstName,
    lastName : this.model.lastName,
    email : this.model.email,
    phoneNumber : this.model.phoneNumber,
    isActive: true,
    id: 0
    };
    if (this.model.id > 0) {
      request.id = this.model.id;
    }

    this.contactInfoService.save(request).subscribe(obj => {
      let response = obj;
    });
  }
}
