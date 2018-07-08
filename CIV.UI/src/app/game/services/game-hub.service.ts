import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { AuthService } from './auth.service';
import { from } from 'rxjs';

@Injectable()
export class GameHubService {
    private connection: HubConnection;
    private baseUrl = 'https://localhost:5001';

  constructor(
    authService: AuthService
  ) {
    this.connection = new HubConnectionBuilder()
      .withUrl(this.baseUrl + '/gameHub', {
        accessTokenFactory: () => authService.token
      })
      .build();
    this.connection
      .start()
      .catch(err => console.error(err.toString()));
  }

  public join(gameName: string) {
    return from(this.connection.invoke('Join', gameName));
  }
}
