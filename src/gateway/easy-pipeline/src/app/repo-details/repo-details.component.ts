import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-repo-details',
  templateUrl: './repo-details.component.html',
  styleUrls: ['./repo-details.component.sass']
})
export class RepoDetailsComponent implements OnInit {

  constructor() {  console.log("constructor details");}

  ngOnInit(): void {
    console.log("ts");

  }

}
