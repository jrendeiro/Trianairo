import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Saint } from '../Models/saint';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  sendSaint(saint: Saint): Observable<any> {
    const body=JSON.stringify(saint);
    console.log('saint looks like this: ' + body);
    const headers = { 'content-type': 'application/json'}
    return this.http.post(this.baseUrl + 'admin', body, {'headers':headers});
  }
}

