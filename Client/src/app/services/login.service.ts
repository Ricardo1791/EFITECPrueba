import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/Login.model';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url: string = environment.ApiUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();
  
  constructor(private http: HttpClient) { }

  login(username: string, password: string){
    return this.http.post(this.url  + 'auth', {username, password}).pipe(
      map((response: User) => {
        const user = response;
        if (user){
          this.setCurrentUser(user);
          return user;
        }else{
          return null;
        }
      })
    );
  }

  setCurrentUser(user: User){
    sessionStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  logout(){
    sessionStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}
