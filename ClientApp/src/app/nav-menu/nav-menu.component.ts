import { Component } from '@angular/core';
import { MsalService } from '@azure/msal-angular';
import { AppComponent } from '../app.component';
import { ProfileService } from '../Services/profile.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html'
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(public profileService: ProfileService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

}
