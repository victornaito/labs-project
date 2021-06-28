import { NgModule } from '@angular/core';
import { HomeComponent } from './home.component';
import { RouterModule, Routes } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { RepoOptionsComponent } from '../repo-options/repo-options.component';
import { RepoDetailsComponent } from '../repo-details/repo-details.component';
import { RepoResumeComponent } from '../repo-resume/repo-resume.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    children: [
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
    ]
  }
];

@NgModule({
  declarations: [
    HomeComponent,
    RepoOptionsComponent,
    RepoDetailsComponent,
    RepoResumeComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    SharedModule
  ],
  exports: [
    HomeComponent
  ]
})
export class HomeModule { }
