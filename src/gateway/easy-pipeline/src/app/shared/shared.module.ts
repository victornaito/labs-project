import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatSliderModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule,
    FormsModule,
    MatExpansionModule
  ],
  exports: [
    CommonModule,
    MatSliderModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule,
    FormsModule,
    MatExpansionModule
  ]
})
export class SharedModule { }
