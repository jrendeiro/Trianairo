import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProfileService } from './profile.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  baseUrl = environment.apiUrl;
  isAdmin: boolean;

  constructor(private http: HttpClient, public profileService: ProfileService) { }

  login(id: string) {
    this.http.get<boolean>(this.baseUrl + 'login/' + id).subscribe(res => this.isAdmin = res);
  }

}
