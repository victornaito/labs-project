import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RepoResumeComponent } from './repo-resume.component';

describe('RepoResumeComponent', () => {
  let component: RepoResumeComponent;
  let fixture: ComponentFixture<RepoResumeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RepoResumeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RepoResumeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
