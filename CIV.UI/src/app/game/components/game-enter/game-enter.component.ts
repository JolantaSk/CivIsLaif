import { Component, OnInit } from '@angular/core';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-game-enter',
  templateUrl: './game-enter.component.html',
  styleUrls: ['./game-enter.component.css']
})
export class GameEnterComponent implements OnInit {

  public gameName: string;
  public gameInitiated: boolean;
  public playersAdded: boolean;

  constructor(
    private gameService: GameService
  ) { }

  ngOnInit() {
  }

  public addGame(): void {
    this.gameService.create(this.gameName)
      .subscribe(() => this.gameInitiated = true);
  }
}
