import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetBoatsComponent } from './get-boats.component';

describe('GetBoatsComponent', () => {
  let component: GetBoatsComponent;
  let fixture: ComponentFixture<GetBoatsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetBoatsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetBoatsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
