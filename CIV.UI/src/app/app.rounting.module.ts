import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './landing/components/home/home.component';
import { AuthGuard } from './core/services/auth-guard.service';
import { SignInComponent } from './landing/components/sign-in/sign-in.component';
import { CreateGameComponent } from './game/components/create-game/create-game.component';
import { JoinGameComponent } from './game/components/join-game/join-game.component';
import { InGameComponent } from './game/components/in-game/in-game.component';
import { AwaitingGameComponent } from './game/components/awaiting-game/awaiting-game.component';

const appRoutes: Routes = [
    { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'join', component: JoinGameComponent, canActivate: [AuthGuard] },
    {
        path: 'game',
        component: HomeComponent,
        canActivate: [AuthGuard]
    },
    {
        path: 'game/create', component: CreateGameComponent, canActivate: [AuthGuard]
    },
    {
        path: 'game/:name', component: InGameComponent, canActivate: [AuthGuard]
    },
    {
        path: 'game/:name/awaiting', component: AwaitingGameComponent, canActivate: [AuthGuard]
    },
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'sign-in', component: SignInComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      // { enableTracing: true } // <-- debugging purposes only
    )
  ],
  exports: [RouterModule]
})
export class AppRountingModule { }
