import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AccountInfo } from '@azure/msal-common';

const GRAPH_ENDPOINT = 'https://graph.microsoft.com/v1.0/me';

type ProfileType = {
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
  loginDisplay: boolean = false;



  constructor(private http: HttpClient) { }

  getProfile(): ProfileType {
    this.http.get(GRAPH_ENDPOINT).subscribe(profile => {
             this.profile = profile;
           });
    return this.profile;
  }

  setLogin(accounts: AccountInfo[]) {
    // this.loginDisplay = accounts[0].localAccountId == '00000000-0000-0000-45bd-f35bb27e96d7';
    return this.loginDisplay;
  }
}
