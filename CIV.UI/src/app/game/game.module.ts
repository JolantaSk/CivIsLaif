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
import { HomeComponent } from './components/home/home.component';
import { CreateGameComponent } from './components/create-game/create-game.component';
import { SignInComponent } from './components/sign-in/sign-in.component';
import { InGameComponent } from './components/in-game/in-game.component';
import { AwaitingGameComponent } from './components/awaiting-game/awaiting-game.component';
import { AuthGuard } from './services/auth-guard.service';
import { RouterModule } from '../../../node_modules/@angular/router';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    HttpClientModule,
    RouterModule
  ],
  declarations: [
    GameEnterComponent,
    PlayersComponent,
    JoinGameComponent,
    PlayerDisplayComponent,
    GameModeComponent,
    HomeComponent,
    CreateGameComponent,
    SignInComponent,
    InGameComponent,
    AwaitingGameComponent
  ],
  exports: [
    GameEnterComponent
  ],
  providers: [AuthGuard]
})
export class GameModule { }