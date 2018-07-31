import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  redirectUrl: string;

  constructor(
    private httpClient: HttpClient,
    private router: Router
  ) {
  }

  public get token(): string {
        return localStorage.getItem('token');
  }

  public get username(): string {
    return localStorage.getItem('username');
  }

  public get isAuthenticated(): boolean {
        return !!this.token;
  }

  public logout() {
    localStorage.removeItem('token');
    this.router.navigate(['/sign-in']);
  }

  public login(username: string) {
    return this.httpClient.post<any>('/api/auth/login', {username})
      .pipe(map(r => {
        localStorage.setItem('token', r.token);
        localStorage.setItem('username', username);
        return r.token;
    }));
  }
}
