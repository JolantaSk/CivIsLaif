import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Player } from '../../../core/models/player';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.css']
})
export class PlayersComponent implements OnInit {

  public players: Array<Player>;
  @Output() addPlayers = new EventEmitter<Array<Player>>();

  constructor() { }

  ngOnInit() {
    this.players = new Array<Player>();
    this.players.push(new Player());
  }

  public addPlayer(): void {
    this.players.push(new Player());
  }

  public onAddPlayers(): void {
    this.addPlayers.emit(this.players);
  }
}