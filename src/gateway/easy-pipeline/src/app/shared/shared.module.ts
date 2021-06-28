import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatSliderModule,
    MatSelectModule,

  ],
  exports: [
    CommonModule,
    MatSliderModule,
    MatSelectModule,
  ]
})
export class SharedModule { }
