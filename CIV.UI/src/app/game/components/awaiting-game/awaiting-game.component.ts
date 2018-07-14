import { Component, OnInit } from '@angular/core';
import { Player } from '../../../core/models/player';
import { ActivatedRoute, Router } from '@angular/router';
import { GameHubService } from '../../services/game-hub.service';
import { GameService } from '../../services/game.service';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-awaiting-game',
  templateUrl: './awaiting-game.component.html',
  styleUrls: ['./awaiting-game.component.css']
})
export class AwaitingGameComponent implements OnInit {
  players: Array<Player>;
  gameName: string;
  isCurrentUserCreator: boolean;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService,
    private gameHubService: GameHubService,
    private gameService: GameService
  ) { }

  ngOnInit() {
    this.gameHubService.gameStarted.subscribe(() => {
      this.router.navigate(['/game', this.gameName]);
    });

    this.route.params.subscribe(({name}) => {
      this.gameName = name;
      this.gameService.getPlayers(name)
        .subscribe(players => this.players = players);

      this.gameService.getCreator(name)
        .subscribe(({username}) => {
          this.isCurrentUserCreator = username === this.authService.username;
        });
    });
  }

  startGame() {
    this.gameHubService.start(this.gameName);
  }
}
