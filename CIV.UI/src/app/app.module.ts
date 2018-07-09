import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { GameModule } from './game/game.module';
import { CoreModule } from './core/core.module';
import { GameStateService } from './core/services/game-state.service';
import { AppRountingModule } from './app.rounting.module';
import { httpInterceptorProviders } from './http-interceptors/http-interceptor-provider';
import { LandingModule } from './landing/landing.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    GameModule,
    LandingModule,
    CoreModule,
    AppRountingModule
  ],
  providers: [GameStateService, httpInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
