import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Client';
  userData: any;
  constructor(private httpClient: HttpClient) {
  }

  ngOnInit(): void {
    this.httpClient.get(``).subscribe({
      next:response => this.userData = response
    })
  }
}
