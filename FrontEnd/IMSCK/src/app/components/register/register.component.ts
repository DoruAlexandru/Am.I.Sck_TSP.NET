import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ServicesService } from 'src/app/services/services.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
    repassword: new FormControl('')
  });

  constructor(private registerService: ServicesService, private router: Router) { }

  ngOnInit(): void {
  }

  onRegister(form: FormGroup): void {
    this.registerService.registerUser(form.getRawValue()).subscribe(res => {
      this.router.navigate(['/login']);
    })
  }
}
