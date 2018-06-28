import { Injectable } from '@angular/core';
import { GameMode } from '../../intro/enums/game-mode.enum';
import { Player } from '../models/player';

@Injectable({
  providedIn: 'root'
})
export class GameStateService {

  private Players: Array<Player>;
  private CurrentPlayer: Player;
  private GameModeSequence: Array<GameMode>;
  private CurrentGameMode: GameMode;

  constructor() { }

  public setPlayers(players: Array<Player>): void {
    this.Players = players;
  }

  public setGameModes(gameModes: Array<GameMode>) {
    this.GameModeSequence = gameModes;
  }

  public switchTurns(): void {
  }

  public switchModes(): void {
  }
}
