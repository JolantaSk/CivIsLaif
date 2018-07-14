import { Component, OnInit, Input } from '@angular/core';
import { Player } from '../../../core/models/player';
import { GameHubService } from '../../services/game-hub.service';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-join-game',
  templateUrl: './join-game.component.html',
  styleUrls: ['./join-game.component.css']
})
export class JoinGameComponent implements OnInit {

  public players: Array<Player>;
  public username: string;
  @Input() gameName: string;

  constructor(
    private gameService: GameService,
    private gameHubService: GameHubService
  ) { }

  ngOnInit() {
    this.gameService.getPlayers(this.gameName)
      .subscribe(players => this.players = players);
  }

  join() {
    this.gameHubService.join(this.gameName);
  }
}
