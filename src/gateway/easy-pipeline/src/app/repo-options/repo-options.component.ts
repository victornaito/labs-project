import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBarHorizontalPosition, MatSnackBarVerticalPosition, MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-repo-options',
  templateUrl: './repo-options.component.html',
  styleUrls: ['./repo-options.component.sass']
})
export class RepoOptionsComponent implements OnInit {
  form: FormGroup;
  horizontalPosition: MatSnackBarHorizontalPosition = "center";
  verticalPosition: MatSnackBarVerticalPosition = "top";

  constructor(private fb: FormBuilder,
              private router: Router,
              private snackBar: MatSnackBar) {
    this.form = this.fb.group({
      useDockerBuild: [null],
      dockerPushToContainerRegistry: [null],
      tests: [null],
      publishToServer: [null],
    });
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if (!this.form.valid) {
      this.snackBar.open('Cannonball!!', 'Splash', {
        horizontalPosition: this.horizontalPosition,
        verticalPosition: this.verticalPosition,
      });

      return;
    }
    this.router.navigateByUrl("details");
  }

}
