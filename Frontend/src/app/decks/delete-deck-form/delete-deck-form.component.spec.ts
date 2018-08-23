import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteDeckFormComponent } from './delete-deck-form.component';

describe('DeleteDeckFormComponent', () => {
  let component: DeleteDeckFormComponent;
  let fixture: ComponentFixture<DeleteDeckFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeleteDeckFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeleteDeckFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
