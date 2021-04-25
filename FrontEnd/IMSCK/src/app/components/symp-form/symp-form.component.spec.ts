import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SympFormComponent } from './symp-form.component';

describe('SympFormComponent', () => {
  let component: SympFormComponent;
  let fixture: ComponentFixture<SympFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SympFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SympFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
