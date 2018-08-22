import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserDecksTableComponent } from './user-decks-table.component';

describe('UserDecksTableComponent', () => {
  let component: UserDecksTableComponent;
  let fixture: ComponentFixture<UserDecksTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserDecksTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserDecksTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
