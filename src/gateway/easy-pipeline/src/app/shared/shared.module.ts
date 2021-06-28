import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatSliderModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule
  ],
  exports: [
    CommonModule,
    MatSliderModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule
  ]
})
export class SharedModule { }
