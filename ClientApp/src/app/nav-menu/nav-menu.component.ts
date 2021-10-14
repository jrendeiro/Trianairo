import { Component } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { AppComponent } from '../app.component';
import { LoginService } from '../Services/login.service';
import { ProfileService } from '../Services/profile.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(public profileService: ProfileService, public loginService: LoginService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
