import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardDeckDetailsComponent } from './card-deck-details.component';

describe('CardDeckDetailsComponent', () => {
  let component: CardDeckDetailsComponent;
  let fixture: ComponentFixture<CardDeckDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardDeckDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardDeckDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
