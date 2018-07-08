import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:5001';
  private _token: string;

  constructor(
    private httpClient: HttpClient
  ) { }

  public get token(): string {
    return this._token;
  }

  public get isAuthenticated(): boolean {
    return !!this._token;
  }

  public login(username: string) {
    this.httpClient.post<string>(this.baseUrl + '/api/auth/login', {username})
            .toPromise()
            .then(r => this._token = r);
  }
}
