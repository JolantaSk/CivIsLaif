import { Component, OnInit } from '@angular/core';
import { GameService } from '../../services/game.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-game',
  templateUrl: './create-game.component.html',
  styleUrls: ['./create-game.component.css']
})
export class CreateGameComponent implements OnInit {
  gameName: string;

  constructor(
    private gameService: GameService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  create() {
    this.gameService.create(this.gameName)
      .subscribe(() => this.router.navigate([`/game/${this.gameName}/awaiting`]));
  }
}
