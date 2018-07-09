import { Component, OnInit } from '@angular/core';
import { GameHubService } from '../../services/game-hub.service';
import { Observable } from '../../../../../node_modules/rxjs';
import { GameService } from '../../services/game.service';
import { ActivatedRoute } from '../../../../../node_modules/@angular/router';

@Component({
  selector: 'app-in-game',
  templateUrl: './in-game.component.html',
  styleUrls: ['./in-game.component.css']
})
export class InGameComponent implements OnInit {
  state: GameState;
  receivedStateChange = false;

  constructor(
    private gameHubService: GameHubService,
    private gameService: GameService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit() {
    this.gameHubService.gameEvents.subscribe((state: GameState) => {
        this.state = state;
        this.receivedStateChange = true;
    });
    this.route.params.subscribe(({name}) => {
      this.gameService.getState(name)
        .subscribe(state => {
          if (!this.receivedStateChange) {
            this.state = state;
          }
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
