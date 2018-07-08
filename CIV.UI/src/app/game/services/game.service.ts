import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GameService {
    private baseUrl = 'https://localhost:5001';

  constructor(
    private httpClient: HttpClient
  ) {
  }

  public start(gameName: string) {
    return this.httpClient.post(this.baseUrl + '/api/game', {name: gameName});
  }
}
