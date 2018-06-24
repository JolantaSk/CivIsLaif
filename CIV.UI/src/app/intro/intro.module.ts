import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameEnterComponent } from './game-enter/game-enter.component';
import { PlayersComponent } from './players/players.component';
import { PlayerComponent } from './player/player.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [GameEnterComponent, PlayersComponent, PlayerComponent],
  exports: [
    GameEnterComponent
  ]
})
export class IntroModule { }
