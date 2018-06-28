import { Component, OnInit, Input } from '@angular/core';
import { Player } from '../../../core/models/player';

@Component({
  selector: 'app-player-display',
  templateUrl: './player-display.component.html',
  styleUrls: ['./player-display.component.css']
})
export class PlayerDisplayComponent implements OnInit {

  @Input() players: Array<Player>;
  constructor() { }

  ngOnInit() {
  }

}
