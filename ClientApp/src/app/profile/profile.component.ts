import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProfileService } from '../Services/profile.service';
import { MsalService } from '@azure/msal-angular';

const GRAPH_ENDPOINT = 'https://graph.microsoft.com/v1.0/me';

type ProfileType = {
  givenName?: string,
  surname?: string,
  userPrincipalName?: string,
  id?: string
};

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html'
})
export class ProfileComponent implements OnInit {
  profile!: ProfileType;

  constructor(public profileService: ProfileService) { }

  ngOnInit() {
    this.getProfile();
  }

  getProfile() {
 
  this.profileService.getProfile();
}

}