import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopcustomersComponent } from './topcustomers.component';

describe('TopcustomersComponent', () => {
  let component: TopcustomersComponent;
  let fixture: ComponentFixture<TopcustomersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopcustomersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopcustomersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
