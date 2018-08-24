import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardCreateFormComponent } from './card-create-form.component';

describe('CardCreateFormComponent', () => {
  let component: CardCreateFormComponent;
  let fixture: ComponentFixture<CardCreateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardCreateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardCreateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
