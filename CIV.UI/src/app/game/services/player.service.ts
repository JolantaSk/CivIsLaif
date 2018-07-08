import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Player } from '../../core/models/player';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  private baseUrl = 'https://localhost:5001';

  constructor(
    private httpClient: HttpClient
  ) { }

  public AddPlayers(player: Array<Player>): Observable<any> {
    return new Observable();
  }

  public getPlayers(gameName: string): Observable<Player[]> {
    const resource = this.httpClient.get<string[]>(this.baseUrl + '/api/player', {
        params: {name: gameName}
    });
    return map<string[], Player[]>(r => r.map(n => {
      const player = new Player();
      player.name = n;
      return player;
    }))(resource);
  }
}
