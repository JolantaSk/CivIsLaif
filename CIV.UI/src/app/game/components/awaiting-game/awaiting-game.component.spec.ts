import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AwaitingGameComponent } from './awaiting-game.component';

describe('AwaitingGameComponent', () => {
  let component: AwaitingGameComponent;
  let fixture: ComponentFixture<AwaitingGameComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AwaitingGameComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AwaitingGameComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
