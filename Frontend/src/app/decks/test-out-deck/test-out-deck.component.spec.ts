import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestOutDeckComponent } from './test-out-deck.component';

describe('TestOutDeckComponent', () => {
  let component: TestOutDeckComponent;
  let fixture: ComponentFixture<TestOutDeckComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TestOutDeckComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestOutDeckComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
