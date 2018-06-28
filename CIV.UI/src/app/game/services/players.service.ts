import { Injectable } from '@angular/core';
import { HttpClient } from 'selenium-webdriver/http';
import { Observable } from 'rxjs/internal/Observable';
import { Player } from '../../core/models/player';

@Injectable({
  providedIn: 'root'
})
export class PlayersService {

  constructor(
  ) { }

  public AddPlayers(player: Array<Player>): Observable<any> {
    return new Observable();
  }
}
