import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Player } from '../../core/models/player';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PlayerService {
  constructor(
    private httpClient: HttpClient
  ) { }

  public getPlayers(gameName: string): Observable<Player[]> {
    const resource = this.httpClient.get<string[]>('/api/player', {
        params: {name: gameName}
    });
    return map<string[], Player[]>(r => r.map(n => {
      const player = new Player();
      player.name = n;
      return player;
    }))(resource);
  }
}
