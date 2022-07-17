import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginDTO, User } from 'src/app/models/Login.model';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {
  model = new LoginDTO();
  currentUser$: Observable<User>;

  constructor(public route: Router, public loginService: LoginService) { }

  ngOnInit(): void {
    this.currentUser$ = this.loginService.currentUser$;
  }

  login(){
    this.loginService.login(this.model.username, this.model.password).subscribe(() => {
      this.route.navigateByUrl('');
    });
  }

  logout(){
    this.loginService.logout();
  }
}
