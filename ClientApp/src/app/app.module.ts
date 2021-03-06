import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { SaintsComponent } from './saints/saints.component';
import { AdminComponent } from './admin/admin.component';
import { MsalGuard, MsalInterceptor, MsalModule, MsalRedirectComponent } from '@azure/msal-angular';
import { InteractionType, PublicClientApplication } from '@azure/msal-browser';
import { ProfileComponent } from './profile/profile.component';
import { environment } from 'src/environments/environment';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import {MatRadioModule, MAT_RADIO_DEFAULT_OPTIONS} from '@angular/material/radio';

const isIE = window.navigator.userAgent.indexOf('MSIE ') > -1 || window.navigator.userAgent.indexOf('Trident/') > -1;


@NgModule({
  declarations: [	
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    SaintsComponent,
    AdminComponent,
    ProfileComponent
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'saints', component: SaintsComponent },
      { path: 'admin', component: AdminComponent },
      { path: 'profile', component: ProfileComponent },
      { path: 'redirect',   redirectTo: '/saints', pathMatch: 'full' }
    ]),
    ReactiveFormsModule,
    MsalModule.forRoot( new PublicClientApplication({
      auth: {
        clientId: '839885f7-9e65-4e44-894e-2d47a46318cc', // This is your client ID
        authority: 'https://login.microsoftonline.com/consumers', // This is your tenant ID
        redirectUri: environment.redirectUrl // This is your redirect URI
      },
      cache: {
        cacheLocation: 'localStorage',
        storeAuthStateInCookie: isIE, // Set to true for Internet Explorer 11
      }
    }), {
      interactionType: InteractionType.Redirect,
      authRequest: {
        scopes: ['user.read']
        }
    }, {
      interactionType: InteractionType.Redirect, // MSAL Interceptor Configuration
      protectedResourceMap: new Map([ 
          ['https://graph.microsoft.com/v1.0/me', ['user.read']]
      ])
    }),
    BrowserAnimationsModule,
    MatRadioModule,
    MatSnackBarModule,
  ],  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: MsalInterceptor,
      multi: true      
    },
    MsalGuard,
    {
      provide: MAT_RADIO_DEFAULT_OPTIONS,
      useValue: { color: 'accent' },
  }
  ],
  bootstrap: [AppComponent, MsalRedirectComponent]
})
export class AppModule { }
