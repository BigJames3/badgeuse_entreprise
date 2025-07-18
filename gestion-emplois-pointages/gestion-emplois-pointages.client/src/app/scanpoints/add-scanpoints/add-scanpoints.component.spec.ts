import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddScanpointsComponent } from './add-scanpoints.component';

describe('AddScanpointsComponent', () => {
  let component: AddScanpointsComponent;
  let fixture: ComponentFixture<AddScanpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddScanpointsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddScanpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
