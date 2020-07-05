import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RainReportComponent } from './rain-report.component';

describe('RainReportComponent', () => {
  let component: RainReportComponent;
  let fixture: ComponentFixture<RainReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RainReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RainReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
