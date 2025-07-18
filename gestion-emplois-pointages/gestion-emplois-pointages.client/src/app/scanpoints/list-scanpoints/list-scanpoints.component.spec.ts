import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListScanpointsComponent } from './list-scanpoints.component';

describe('ListScanpointsComponent', () => {
  let component: ListScanpointsComponent;
  let fixture: ComponentFixture<ListScanpointsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListScanpointsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListScanpointsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
