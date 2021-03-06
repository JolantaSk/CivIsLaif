import { Injectable } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { AuthService } from '../../core/services/auth.service';
import { Subject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameHubService {
    private connection: HubConnection;
    private retries = 0;
    gameStarted = new Subject<void>();
    gameEvents = new Subject<any>();
    connected = new Subject<void>();
    disconnected = new Subject<void>();

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
      .then(() => this.connected.next())
      .catch(err => console.error(err.toString()));
    this.connection.on('GameStarted', () => this.gameStarted.next());
    this.connection.on('GameEvent', (e) => this.gameEvents.next(e));
    this.connection.onclose(() => this.onDisconnected());
  }

  private onDisconnected() {
    if (this.retries >= 3) {
      this.retries = 0;
      this.disconnected.next();
    }
    this.connection.start();
    this.retries++;
  }

  public join(gameName: string) {
    return this.connection.invoke('Join', gameName);
  }

  public start(gameName: string) {
    return this.connection.invoke('Start', gameName);
  }
}
