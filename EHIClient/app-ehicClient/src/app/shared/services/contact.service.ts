import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import contact from '../models/contact';

@Injectable()
// tslint:disable-next-line:class-name
export default class contactservice {
  // public API = 'https://localhost:44386/api';
  public API = 'https://ehiwebapi.azurewebsites.net/api';
  public ContactAPI = `${this.API}/Contact`;
  public ContactSummaryAPI = `${this.API}/Contact/GetSummary`;

  private data: contact ;
  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<contact>> {
    return this.http.get<Array<contact>>(this.ContactAPI);
  }

  get(id: string) {
    return this.http.get(`${this.ContactAPI}/${id}`);
  }

  getSummary() {
    return this.http.get(`${this.ContactSummaryAPI}`);
  }

  save(sugarLevel: any): Observable<contact> {
    let result: Observable<contact>;
    if (sugarLevel.id) {
      result = this.http.put<contact>(`${this.ContactAPI}/${sugarLevel.id}`, sugarLevel  );
    } else {
      result = this.http.post<contact>(this.ContactAPI, sugarLevel);
    }
    return result;
  }

  remove(id: number) {
    return this.http.delete(`${this.ContactAPI}/${id.toString()}`);
  }

  setData(data: contact) {
      this.data = data;
  }

  getData(): contact{
      return this.data;
  }
}
