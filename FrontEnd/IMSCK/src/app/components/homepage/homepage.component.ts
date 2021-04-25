import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.scss'],
})
export class HomepageComponent implements OnInit {
  isHomepage = true;

  constructor(private router: Router) {}

  ngOnInit(): void {
    if (this.router.url === '/homepage') {
      this.isHomepage = true;
    } else {
      this.isHomepage = false;
    }
  }

  logout(): void {
    localStorage.setItem('token', 'null');
  }
}
