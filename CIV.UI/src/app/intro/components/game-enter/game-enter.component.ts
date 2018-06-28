import { Component, OnInit } from '@angular/core';
import { Player } from '../../models/player';
import { PlayersService } from '../../services/players.service';

@Component({
  selector: 'app-game-enter',
  templateUrl: './game-enter.component.html',
  styleUrls: ['./game-enter.component.css']
})
export class GameEnterComponent implements OnInit {

  public gameName: string;
  public players: Array<Player>;
  public gameInitiated: boolean;
  public playersAdded: boolean;

  constructor(
    private playersService: PlayersService
  ) { }

  ngOnInit() {
  }

  public addGame(): void {
    this.gameInitiated = true;
  }

  public addPlayers(players: any): void {
    this.players = players;
    this.playersAdded = true;
    this.playersService.AddPlayers(this.players).subscribe();
    console.log(this.players);
  }

}
