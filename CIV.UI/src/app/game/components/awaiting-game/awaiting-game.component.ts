import { Component, OnInit } from '@angular/core';
import { PlayerService } from '../../services/player.service';
import { Player } from '../../../core/models/player';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

@Component({
  selector: 'app-awaiting-game',
  templateUrl: './awaiting-game.component.html',
  styleUrls: ['./awaiting-game.component.css']
})
export class AwaitingGameComponent implements OnInit {
  public players: Array<Player>;

  constructor(
    private playerService: PlayerService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.route.paramMap.pipe(switchMap((params: ParamMap) =>
      this.playerService.getPlayers(params.get('name'))))
        .subscribe(players => this.players = players);
  }
}
