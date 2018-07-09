import { Component, OnInit } from '@angular/core';
import { GameHubService } from '../../services/game-hub.service';
import { race } from 'rxjs/operators';
import { GameService } from '../../services/game.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../../core/services/auth.service';

@Component({
  selector: 'app-in-game',
  templateUrl: './in-game.component.html',
  styleUrls: ['./in-game.component.css']
})
export class InGameComponent implements OnInit {
  state: GameState;
  currentPlayersTurn: boolean;

  constructor(
    private gameHubService: GameHubService,
    private gameService: GameService,
    private authService: AuthService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.route.params.subscribe(({name}) => {
      this.gameService.getState(name)
        .pipe(race(this.gameHubService.gameEvents))
        .subscribe(state => {
            this.state = state;
            this.currentPlayersTurn = state && state.currentPlayer === this.authService.username;
        });
    });

    setInterval(() => {
      if (this.state) {
        this.state.timeElapsedInMilliseconds += 1000;
      }
    }, 1000);
  }
}

interface GameState {
  turn: number;
  phase: string;
  currentPlayer: string;
  timeElapsedInMilliseconds: number;
}
