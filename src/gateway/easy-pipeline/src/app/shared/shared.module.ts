import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatButtonModule } from '@angular/material/button';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// import { MatSnackBarModule } from '@angular/material/snack-bar/snack-bar-module';
import { MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    MatSliderModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatExpansionModule,
    MatSnackBarModule,
    // MatSnackBarModule,
  ],
  exports: [
    CommonModule,
    FormsModule,
    MatSliderModule,
    MatSelectModule,
    MatCheckboxModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatExpansionModule,
    // MatSnackBarModule,
    MatSnackBarModule
  ]
})
export class SharedModule { }
