import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GameEnterComponent } from './components/game-enter/game-enter.component';
import { PlayersComponent } from './components/players/players.component';
import { PlayerDisplayComponent } from './components/player-display/player-display.component';
import { GameModeComponent } from './components/game-mode/game-mode.component';
import { SharedModule } from '../shared/shared.module';
import { HttpClientModule } from '@angular/common/http';
import { JoinGameComponent } from './components/join-game/join-game.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    HttpClientModule
  ],
  declarations: [
    GameEnterComponent,
    PlayersComponent,
    JoinGameComponent,
    PlayerDisplayComponent, GameModeComponent
  ],
  exports: [
    GameEnterComponent
  ]
})
export class GameModule { }
