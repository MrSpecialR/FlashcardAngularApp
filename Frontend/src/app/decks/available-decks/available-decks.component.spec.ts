import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AvailableDecksComponent } from './available-decks.component';

describe('AvailableDecksComponent', () => {
  let component: AvailableDecksComponent;
  let fixture: ComponentFixture<AvailableDecksComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AvailableDecksComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AvailableDecksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
