import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { RepoDetailsComponent } from 'src/app/repo-details/repo-details.component';
import { RepoOptionsComponent } from 'src/app/repo-options/repo-options.component';
import { RepoResumeComponent } from 'src/app/repo-resume/repo-resume.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HomeComponent } from './home.component';


@NgModule({
  declarations: [
    HomeComponent,
    RepoOptionsComponent,
    RepoDetailsComponent,
    RepoResumeComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    HomeRoutingModule
  ],
  exports: [
    HomeComponent,
    RepoOptionsComponent,
    RepoDetailsComponent,
    RepoResumeComponent,
  ]
})
export class HomeModule { }
