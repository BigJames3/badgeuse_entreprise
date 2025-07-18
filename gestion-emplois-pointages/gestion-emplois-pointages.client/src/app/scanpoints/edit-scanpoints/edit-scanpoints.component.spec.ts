import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditScanpointsComponent } from './edit-scanpoints.component';

describe('EditScanpointsComponent', () => {
  let component: EditScanpointsComponent;
  let fixture: ComponentFixture<EditScanpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [EditScanpointsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EditScanpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
