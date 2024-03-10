import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm } from '@angular/forms';
import { ApiService } from '../api.service';
import { PersonalDataInformation } from './PersonalDataInformation';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-personal-data-form',
  templateUrl: './personal-data-form.component.html',
  styleUrls: ['./personal-data-form.component.css']
})
export class PersonalDataFormComponent {

    accessToken: string;
    userData: PersonalDataInformation;
    firstName: string;

    constructor(private oauthService: OAuthService, private apiService: ApiService) { 



    }

  ngOnInit() {
      this.accessToken = this.oauthService.getAccessToken();

      this.apiService.getUserData(this.accessToken).subscribe(
          (data: PersonalDataInformation) => {
            this.userData = data;
          },
          (error) => {
            console.error('Error loading user data:', error);
          }
        );


  }

  submitForm(form: NgForm) {
    if (form.valid) {
      const personalData: PersonalDataInformation = {
        firstName: form.value.firstName,
        lastName: form.value.lastName,
        phoneNumber: form.value.phoneNumber,
        email: form.value.email,
        address: form.value.address,
        webSite: form.value.website,
        profile: form.value.profile,
        education: form.value.education,
        employmentHistory: form.value.employmentHistory,
        languages: form.value.languages,
        certifications: form.value.certifications
      };

        this.accessToken = this.oauthService.getAccessToken();

        this.apiService.updatePersonalData(this.accessToken, personalData).subscribe(
        () => {
          // Reset the form after successful submission
          console.log('Form submitted successfully');
        },
        error => {
          console.error('Error submitting form:', error);
        }
      );
    }
  }

}