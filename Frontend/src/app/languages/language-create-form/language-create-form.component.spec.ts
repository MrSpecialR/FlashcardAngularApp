import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LanguageCreateFormComponent } from './language-create-form.component';

describe('LanguageCreateFormComponent', () => {
  let component: LanguageCreateFormComponent;
  let fixture: ComponentFixture<LanguageCreateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LanguageCreateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LanguageCreateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
