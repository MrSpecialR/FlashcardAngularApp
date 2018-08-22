import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserSubscribtionDecksTableComponent } from './user-subscribtion-decks-table.component';

describe('UserSubscribtionDecksTableComponent', () => {
  let component: UserSubscribtionDecksTableComponent;
  let fixture: ComponentFixture<UserSubscribtionDecksTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserSubscribtionDecksTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserSubscribtionDecksTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
