import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GameEnterComponent } from './game-enter.component';

describe('GameEnterComponent', () => {
  let component: GameEnterComponent;
  let fixture: ComponentFixture<GameEnterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GameEnterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GameEnterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
