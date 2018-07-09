import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { AuthService } from '../../core/services/auth.service';
import { Observable, empty, Subject } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GameHubService {
    private connection: HubConnection;
    gameStarted = new Subject<void>();

  constructor(
    authService: AuthService
  ) {
    this.connection = new HubConnectionBuilder()
      .withUrl('/gameHub', {
        accessTokenFactory: () => authService.token
      })
      .build();
    this.connection
      .start()
      .catch(err => console.error(err.toString()));
    this.connection.on('GameStarted', () => this.gameStarted.next());
  }

  public join(gameName: string) {
    return this.connection.invoke('Join', gameName);
  }

  public start(gameName: string) {
    return this.connection.invoke('Start', gameName);
  }

  public getGameStream() {
    return this.connection.stream('GameEvent');
  }
}
