import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteScanpointsComponent } from './delete-scanpoints.component';

describe('DeleteScanpointsComponent', () => {
  let component: DeleteScanpointsComponent;
  let fixture: ComponentFixture<DeleteScanpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteScanpointsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteScanpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
