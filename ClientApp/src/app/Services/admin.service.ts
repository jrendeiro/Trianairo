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

  sendSaint(name: string): Observable<any> {
    const body=name;
    const headers = { 'content-type': 'application/json'}
    return this.http.post(this.baseUrl + 'admin', body, {'headers':headers});
  }

  deleteSaint(saint: string) {
    return this.http.delete(this.baseUrl + 'admin/' + saint);
  }
}
