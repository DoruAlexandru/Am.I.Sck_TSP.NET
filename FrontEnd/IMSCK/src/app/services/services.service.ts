import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {

  constructor(private readonly http: HttpClient) { }

  checkUser(body: any): Observable<any>{
    return this.http.post('https://localhost:5001/login',body);
  }

  registerUser(body: any): Observable<any>{
    return this.http.post('https://localhost:5001/register',body);
  }

  sayHi(): Observable<any>{
    return this.http.get('https://localhost:5001/Hi',
    {
      headers: new HttpHeaders(this.setHeaders())
    });
  }

  private setHeaders() {
    let token = localStorage.getItem('token');
    let headers = {
      'Authorization': `Bearer ${token}`
    };
    return headers;
  }
}
