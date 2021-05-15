import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import contact from '../models/contact';

@Injectable()
// tslint:disable-next-line:class-name
export default class contactservice {
  public API = 'https://localhost:44386/api';
  public SUGARLEVELS_API = `${this.API}/contact`;

  private data: contact ;
  constructor(private http: HttpClient) {}

  getAll(): Observable<Array<contact>> {
    return this.http.get<Array<contact>>(this.SUGARLEVELS_API);
  }

  get(id: string) {
    return this.http.get(`${this.SUGARLEVELS_API}/${id}`);
  }

  save(sugarLevel: any): Observable<contact> {
    let result: Observable<contact>;
    if (sugarLevel.id) {
      result = this.http.put<contact>(`${this.SUGARLEVELS_API}/${sugarLevel.id}`, sugarLevel  );
    } else {
      result = this.http.post<contact>(this.SUGARLEVELS_API, sugarLevel);
    }
    return result;
  }

  remove(id: number) {
    return this.http.delete(`${this.SUGARLEVELS_API}/${id.toString()}`);
  }



  setData(data: contact) {
      this.data = data;
  }

  getData(): contact{ 
      return this.data;
  }
}
