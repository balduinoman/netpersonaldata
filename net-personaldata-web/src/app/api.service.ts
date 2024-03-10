import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PersonalDataInformation } from './personal-data-form/PersonalDataInformation'; 

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private apiUrl = 'http://localhost:25493/api/v1/PersonalDataInformation';

  constructor(private http: HttpClient) {}

  getUserData(accessToken: string): Observable<PersonalDataInformation> {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${accessToken}`);
    return this.http.get<PersonalDataInformation>(`${this.apiUrl}`, { headers });
  }

  addPersonalData(accessToken: string, personalData: PersonalDataInformation) {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${accessToken}`);
    return this.http.post(this.apiUrl, personalData, { headers });
  }

  updatePersonalData(accessToken: string, personalData: PersonalDataInformation) {
    const headers = new HttpHeaders().set('Authorization', `Bearer ${accessToken}`);
    return this.http.put(this.apiUrl, personalData, { headers });
  }
}