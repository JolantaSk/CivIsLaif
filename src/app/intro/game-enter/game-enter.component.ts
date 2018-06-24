import { Component, OnInit } from '@angular/core';
import { Player } from '../player/player';

@Component({
  selector: 'app-game-enter',
  templateUrl: './game-enter.component.html',
  styleUrls: ['./game-enter.component.css']
})
export class GameEnterComponent implements OnInit {

  public gameName: string;
  public players: Array<Player>;
  public gameInitiated: boolean;

  constructor() { }

  ngOnInit() {
    this.players = new Array<Player>();
  }

  public addGame(): void {
    this.gameInitiated = true
  }

}
