import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RepoDetailsComponent } from 'src/app/repo-details/repo-details.component';
import { RepoOptionsComponent } from 'src/app/repo-options/repo-options.component';
import { RepoResumeComponent } from 'src/app/repo-resume/repo-resume.component';
import { HomeComponent } from './home.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
  },
  {
    path: 'options',
    component: RepoOptionsComponent
  },
  {
    path: 'details',
    component: RepoDetailsComponent
  },
  {
    path: 'resume',
    component: RepoResumeComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
