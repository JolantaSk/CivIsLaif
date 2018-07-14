import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from '../../core/services/auth.service';
import { Player } from '../../core/models/player';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

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

  public getPlayers(gameName: string): Observable<Player[]> {
    const resource = this.httpClient.get<string[]>(`/api/game/${gameName}/players`);
    return map<string[], Player[]>(r => r.map(n => {
      const player = new Player();
      player.name = n;
      return player;
    }))(resource);
  }
}
