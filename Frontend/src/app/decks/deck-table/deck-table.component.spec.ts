
import { fakeAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeckTableComponent } from './deck-table.component';

describe('DeckTableComponent', () => {
  let component: DeckTableComponent;
  let fixture: ComponentFixture<DeckTableComponent>;

  beforeEach(fakeAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ DeckTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeckTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should compile', () => {
    expect(component).toBeTruthy();
  });
});
