import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {

  constructor(private router: Router,
            private route: ActivatedRoute) { }

  ngOnInit( ): void {
  }

  public redirectTo() {
    this.router.navigateByUrl("options");
  }
}
