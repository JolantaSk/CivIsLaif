import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  redirectUrl: string;
  username: string;

  constructor(
    private httpClient: HttpClient
  ) {
  }

  public get token(): string {
        return localStorage.getItem('token');
  }

  public get isAuthenticated(): boolean {
        return !!this.token;
  }

  public login(username: string) {
    const o = this.httpClient.post<any>('/api/auth/login', {username});
    return map<any, string>(r => {
        localStorage.setItem('token', r.token);
        this.username = username;
        return r.token;
    })(o);
  }
}
