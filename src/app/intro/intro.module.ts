import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GameEnterComponent } from './game-enter/game-enter.component';
import { PlayersComponent } from './players/players.component';
import { PlayerComponent } from './player/player.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [GameEnterComponent, PlayersComponent, PlayerComponent],
  exports: [
    GameEnterComponent
  ]
})
export class IntroModule { }
