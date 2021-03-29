import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl('')
  })

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  onLogin(form: FormGroup): void {
    let username = form.get('username')?.value;
    let password = form.get('password')?.value;
    let body = { username: username, password: password }

    if (username !== '' && username !== null && password !== '' && password !== null) {
      this.http.post('https://localhost:44399/api/login/', body, { responseType: 'json' }).subscribe(
        data => {
          console.log(data)
        }
      )
    }
  }

}
