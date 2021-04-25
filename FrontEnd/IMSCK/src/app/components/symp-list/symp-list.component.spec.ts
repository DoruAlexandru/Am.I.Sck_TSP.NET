import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SympListComponent } from './symp-list.component';

describe('SympListComponent', () => {
  let component: SympListComponent;
  let fixture: ComponentFixture<SympListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SympListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SympListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
