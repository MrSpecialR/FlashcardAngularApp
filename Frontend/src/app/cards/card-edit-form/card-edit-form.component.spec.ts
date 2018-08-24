import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardEditFormComponent } from './card-edit-form.component';

describe('CardEditFormComponent', () => {
  let component: CardEditFormComponent;
  let fixture: ComponentFixture<CardEditFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardEditFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
