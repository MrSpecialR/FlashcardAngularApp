import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CardDeleteFormComponent } from './card-delete-form.component';

describe('CardDeleteFormComponent', () => {
  let component: CardDeleteFormComponent;
  let fixture: ComponentFixture<CardDeleteFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CardDeleteFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CardDeleteFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
