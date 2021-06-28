import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RepoOptionsComponent } from './repo-options.component';

describe('RepoOptionsComponent', () => {
  let component: RepoOptionsComponent;
  let fixture: ComponentFixture<RepoOptionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RepoOptionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RepoOptionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
