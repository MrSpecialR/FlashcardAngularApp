import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserStatisticsTableComponent } from './user-statistics-table.component';

describe('UserStatisticsTableComponent', () => {
  let component: UserStatisticsTableComponent;
  let fixture: ComponentFixture<UserStatisticsTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserStatisticsTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserStatisticsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
