import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Symptom } from '../models/symptom';

@Injectable({
  providedIn: 'root'
})
export class SymptomsService {
  selectedSymptoms: BehaviorSubject<any>;

  constructor(private http: HttpClient) {
    this.selectedSymptoms = new BehaviorSubject({});
   }

  getSymptoms(): Observable<any> {
    return this.http.get('https://localhost:5001/symptom/getAllSymptoms/',
    {
      headers: new HttpHeaders(this.setHeaders())
    })
  }

  setSelectedSymptoms(newList: Symptom[]): void {
    this.selectedSymptoms.next(newList);
  }

  getSelectedSymptoms(): Observable<any> {
    return this.selectedSymptoms;
  }

  private setHeaders() {
    let token = localStorage.getItem('token');
    let headers = {
      'Authorization': `Bearer ${token}`
    };
    return headers;
  }
}
