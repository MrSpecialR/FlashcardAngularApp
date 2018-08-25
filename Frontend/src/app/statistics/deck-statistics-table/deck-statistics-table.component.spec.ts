import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeckStatisticsTableComponent } from './deck-statistics-table.component';

describe('DeckStatisticsTableComponent', () => {
  let component: DeckStatisticsTableComponent;
  let fixture: ComponentFixture<DeckStatisticsTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeckStatisticsTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeckStatisticsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
