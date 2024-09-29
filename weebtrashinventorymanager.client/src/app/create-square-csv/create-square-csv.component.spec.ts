import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateSquareCsvComponent } from './create-square-csv.component';

describe('CreateSquareCsvComponent', () => {
  let component: CreateSquareCsvComponent;
  let fixture: ComponentFixture<CreateSquareCsvComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateSquareCsvComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CreateSquareCsvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
