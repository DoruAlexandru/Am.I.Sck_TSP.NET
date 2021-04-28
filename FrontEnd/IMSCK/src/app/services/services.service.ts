import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private readonly http: HttpClient) { }

  checkUser(body: any): Observable<any>{
    return this.http.post('https://localhost:5001/login/checkUser',body);
  }

  registerUser(body: any): Observable<any>{
    return this.http.post('https://localhost:5001/register/createAccount',body);
  }


  private setHeaders() {
    let token = localStorage.getItem('token');
    let headers = {
      'Authorization': `Bearer ${token}`
    };
    return headers;
  }
}
