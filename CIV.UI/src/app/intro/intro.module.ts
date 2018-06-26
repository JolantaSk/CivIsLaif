import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GameEnterComponent } from './game-enter/game-enter.component';
import { PlayersComponent } from './players/players.component';
import { PlayerDisplayComponent } from './player-display/player-display.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule
  ],
  declarations: [
    GameEnterComponent, 
    PlayersComponent, 
    PlayerDisplayComponent
  ],
  exports: [
    GameEnterComponent
  ]
})
export class IntroModule { }
