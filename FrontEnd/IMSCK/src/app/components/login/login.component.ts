import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

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

  constructor(private router:Router, private readonly service: ServicesService) { }

  ngOnInit(): void {
  }

  onLogin(form: FormGroup): void {
    let username = form.get('username')?.value;
    let password = form.get('password')?.value;
    let body = { username: username, password: password }
    this.service.checkUser(body).subscribe(resp => {
      localStorage.setItem('token',resp.data.token);
      this.router.navigate(['homepage']);

    })
  }

}
