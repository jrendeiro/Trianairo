import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { Component, OnInit } from '@angular/core';
import { filter, takeUntil } from 'rxjs/operators';
import { InteractionStatus } from '@azure/msal-browser';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProfileService } from './Services/profile.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginService } from './Services/login.service';


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
  displayName: string;
  id: string;

  constructor(private broadcastService: MsalBroadcastService, private authService: MsalService
        , private profileService: ProfileService, private _snackBar: MatSnackBar, private loginService: LoginService) { }

  ngOnInit() {
    this.isIframe = window !== window.parent && !window.opener;

    this.broadcastService.inProgress$
    .pipe(
      filter((status: InteractionStatus) => status === InteractionStatus.None),
      takeUntil(this._destroying$)
    )
    .subscribe(() => {
      this.setLoginDisplay();

      if (this.loginDisplay)
        this.getProfile();

    })
  }

  login() {
    this.getProfile();
  }
  
  logout() { // Add log out function here
    this.authService.logoutRedirect({
      postLogoutRedirectUri: environment.redirectUrl
    });
  }
  
  setLoginDisplay() {
    let accounts = this.authService.instance.getAllAccounts();
    this.loginDisplay = accounts.length > 0;
    
    // if (accounts.length > 0 && !this.loginDisplay) {
      //   this._snackBar.open("Not authorized", null, {
        //   duration: this.durationInSeconds * 1000,
        //   });
        
        //   setTimeout(()=>{ this.logout() }, this.durationInSeconds * 1000);
        //}
      }
      
      getProfile() {
        
        this.profileService.getProfile().subscribe(
          profile => {
            this.displayName = profile.displayName;
            this.profileService.displayName = profile.displayName;
            this.profileService.loginDisplay = true;
            this.id = profile.id;
            this.loginService.login(this.id);
          }
          );
      }
      
      ngOnDestroy(): void {
        this._destroying$.next(undefined);
        this._destroying$.complete();
  }
}
