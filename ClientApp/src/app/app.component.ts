import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { Component, OnInit } from '@angular/core';
import { filter, takeUntil } from 'rxjs/operators';
import { InteractionStatus } from '@azure/msal-browser';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProfileService } from './Services/profile.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';
  isIframe = false;
  loginDisplay = false;
  private readonly _destroying$ = new Subject<void>();
  durationInSeconds = 3;

  constructor(private broadcastService: MsalBroadcastService, private authService: MsalService
        , private profileService: ProfileService, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.isIframe = window !== window.parent && !window.opener;

    this.broadcastService.inProgress$
    .pipe(
      filter((status: InteractionStatus) => status === InteractionStatus.None),
      takeUntil(this._destroying$)
    )
    .subscribe(() => {
      this.setLoginDisplay();
    })
  }

  login() {
    this.authService.loginRedirect();
  }

  logout() { // Add log out function here
    this.authService.logoutRedirect({
      postLogoutRedirectUri: environment.redirectUrl
    });
  }

  setLoginDisplay() {
    let accounts = this.authService.instance.getAllAccounts();
    this.loginDisplay = this.profileService.setLogin(accounts);

    if (accounts.length > 0 && !this.loginDisplay) {
      this._snackBar.open("Not authorized", null, {
      duration: this.durationInSeconds * 1000,
      });

      setTimeout(()=>{ this.logout() }, this.durationInSeconds * 1000);
    }
  }

  ngOnDestroy(): void {
    this._destroying$.next(undefined);
    this._destroying$.complete();
  }
}
