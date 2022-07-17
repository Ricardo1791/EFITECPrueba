import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from './models/Login.model';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(public router: Router, public loginService: LoginService) {    
  }

  ngOnInit(): void {
    const user: User = JSON.parse(sessionStorage.getItem('user'));

    if (user) {
      this.loginService.setCurrentUser(user);
    } else {
      this.loginService.logout();
    }
  }
  
}
