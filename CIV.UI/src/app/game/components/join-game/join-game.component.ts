import { Component, OnInit, Input } from '@angular/core';
import { Player } from '../../../core/models/player';
import { PlayerService } from '../../services/player.service';
import { AuthService } from '../../services/auth.service';
import { GameHubService } from '../../services/game-hub.service';

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
    private playerService: PlayerService,
    private gameHubService: GameHubService,
    private authService: AuthService,
  ) { }

  ngOnInit() {
    this.playerService.getPlayers(this.gameName)
      .subscribe(players => this.players = players);
  }

  join() {
    this.gameHubService.join(this.gameName);
  }
}
