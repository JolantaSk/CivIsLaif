import { Injectable } from '@angular/core';
import { Player } from '../models/player';
import { HttpClient } from 'selenium-webdriver/http';
import { Observable } from 'rxjs/internal/Observable';

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
