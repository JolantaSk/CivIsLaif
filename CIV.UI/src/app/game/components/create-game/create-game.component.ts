import { Component, OnInit } from '@angular/core';
import { GameService } from '../../services/game.service';
import { Router } from '@angular/router';
import { GameHubService } from '../../services/game-hub.service';
import { flatMap } from 'rxjs/operators';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.css']
})
export class CreateGameComponent implements OnInit {
  gameName: string;

  constructor(
    private gameService: GameService,
    private gameHubService: GameHubService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  create() {
    this.gameService.create(this.gameName)
    .subscribe(() => this.gameHubService.join(this.gameName)
      .then(() => this.router.navigate([`/game/${this.gameName}/awaiting`])));
  }
}
