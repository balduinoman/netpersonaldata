import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {

    accessToken: string;
    userData: any;

    user = {
      name: 'John Doe',
      email: 'john.doe@example.com',
      image: 'https://via.placeholder.com/150'
    };
  
    timelineItems = [
      { date: '2024-03-09', content: 'Item 1' },
      { date: '2024-03-10', content: 'Item 2' },
      { date: '2024-03-11', content: 'Item 3' }
    ];

    constructor(private oauthService: OAuthService, private apiService: ApiService) { 
        this.accessToken = '';
    }

    ngOnInit() {
        this.accessToken = this.oauthService.getAccessToken();

        this.apiService.getUserData(this.accessToken).subscribe(
            (data) => {
              this.userData = data;
            },
            (error) => {
              console.error('Error loading user data:', error);
            }
          );
    }

}