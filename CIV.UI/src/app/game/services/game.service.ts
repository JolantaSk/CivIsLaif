import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../core/services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
  ) {
  }

  public create(name: string) {
    return this.httpClient.post('/api/game', { name: name, creator: this.authService.username });
  }

  public getCreator(name: string) {
    return this.httpClient.get<any>(`/api/game/${name}/creator`);
  }

  public getState(name: string) {
    return this.httpClient.get<any>(`/api/game/${name}/state`);
  }
}
