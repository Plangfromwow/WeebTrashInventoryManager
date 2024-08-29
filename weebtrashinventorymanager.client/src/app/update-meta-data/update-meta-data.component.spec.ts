import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateMetaDataComponent } from './update-meta-data.component';

describe('UpdateMetaDataComponent', () => {
  let component: UpdateMetaDataComponent;
  let fixture: ComponentFixture<UpdateMetaDataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateMetaDataComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateMetaDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
