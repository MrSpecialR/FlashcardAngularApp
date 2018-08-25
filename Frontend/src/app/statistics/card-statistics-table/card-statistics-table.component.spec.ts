import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardStatisticsTableComponent } from './card-statistics-table.component';

describe('CardStatisticsTableComponent', () => {
  let component: CardStatisticsTableComponent;
  let fixture: ComponentFixture<CardStatisticsTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardStatisticsTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardStatisticsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
