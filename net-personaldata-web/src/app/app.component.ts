import { Component } from '@angular/core';
import { OAuthService, JwksValidationHandler } from 'angular-oauth2-oidc';
import { authConfig } from './sso.config';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title: string = "My Personal Data";

  showPersonalDataForm: boolean = false;
  showHome: boolean = false;

  constructor(private oauthService:OAuthService, private router: Router){
    this.configureSingleSignOn();
  }

  configureSingleSignOn(){
    this.oauthService.configure(authConfig);
    this.oauthService.tokenValidationHandler = new JwksValidationHandler();
    this.oauthService.loadDiscoveryDocumentAndTryLogin();
  }

  login(){
    this.oauthService.initCodeFlow();
  }
  
  logout(){
    this.oauthService.logOut();
  }

  get token(){
    return this.oauthService.getAccessToken();
  }

  toggleChildHome() {
    this.router.navigate(['/home']);
  }

  toggleChildPersonalDataForm() {
    this.router.navigate(['/personal-data-form']);
  }
}