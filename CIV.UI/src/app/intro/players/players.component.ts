import { Component, OnInit, Input } from '@angular/core';
import { Player } from '../player/player';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {

  @Input() players: Array<Player>;
  constructor() { }

  ngOnInit() {
  }

  public addPlayer(): void {
    this.players.push(new Player());
  }
}
