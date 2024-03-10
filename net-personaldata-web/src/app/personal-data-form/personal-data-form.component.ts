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

    constructor(private oauthService: OAuthService, private apiService: ApiService) { 
    }

  submitForm(form: NgForm) {
    if (form.valid) {
      const personalData: PersonalDataInformation = {
        firstName: form.value.firstName,
        lastName: form.value.lastName,
        phoneNumber: form.value.phoneNumber,
        email: form.value.email,
        address: form.value.address,
        photo: form.value.photo
      };

        this.accessToken = this.oauthService.getAccessToken();

        this.apiService.addPersonalData(this.accessToken, personalData).subscribe(
        () => {
          // Reset the form after successful submission
          form.resetForm();
          console.log('Form submitted successfully');
        },
        error => {
          console.error('Error submitting form:', error);
        }
      );
    }
  }

}