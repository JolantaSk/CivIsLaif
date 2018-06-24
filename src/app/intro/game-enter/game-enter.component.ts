import { Component, OnInit } from '@angular/core';
import { Player } from '../player/player';

@Component({
  selector: 'app-game-enter',
  templateUrl: './game-enter.component.html',
  styleUrls: ['./game-enter.component.css']
})
export class GameEnterComponent implements OnInit {

  public gameName: string;
  public players = new Array<Player>();
  constructor() { }

  ngOnInit() {
    // this.players = new Array<Player>();
  }

  public onSubmit(): void {
    console.log("submitted")
  }

  public addGame(): void {

  }

}
