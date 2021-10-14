import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountInfo } from '@azure/msal-common';
import { Observable } from 'rxjs';

const GRAPH_ENDPOINT = 'https://graph.microsoft.com/v1.0/me';

type ProfileType = {
  displayName?: string,
  givenName?: string,
  surname?: string,
  userPrincipalName?: string,
  id?: string
};

@Injectable({
  providedIn: 'root'
})
export class ProfileService {
  profile!: ProfileType;
  loginDisplay= false;
  displayName: string;
  id: string;

  constructor(private http: HttpClient) { }

  getProfile(): Observable<ProfileType> {
    return this.http.get<ProfileType>(GRAPH_ENDPOINT);
  }
}
