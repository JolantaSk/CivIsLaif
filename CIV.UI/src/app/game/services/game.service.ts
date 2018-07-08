import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor(
    private httpClient: HttpClient
  ) {
  }

  public create(gameName: string) {
    return this.httpClient.post('/api/game', {name: gameName});
  }
}
