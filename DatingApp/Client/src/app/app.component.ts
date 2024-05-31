import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Users';
  userData: any;
  constructor(private httpClient: HttpClient) {
  }

  ngOnInit(): void {
    this.httpClient.get(`https://localhost:44311/api/users/all`).subscribe({
      next:response => this.userData = response
    })
  }
}
