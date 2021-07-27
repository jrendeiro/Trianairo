import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Saint } from '../Models/saint';

@Injectable({
  providedIn: 'root'
})
export class SaintService {
baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }

   getSaint<Saint>(name: string): Observable<Saint> {
     let params = new HttpParams();
     return this.http.get<Saint>(this.baseUrl + 'saintsApi/' + name);
    }

   getSaints(): Observable<Saint[]> {
     let params = new HttpParams();
     return this.http.get<Saint[]>(this.baseUrl + 'saintsApi');
    }

   sendSaint(saint: Saint): Observable<any> {
      const body=JSON.stringify(saint);
      const headers = { 'content-type': 'application/json'};
      return this.http.post(this.baseUrl + 'admin', body, {'headers':headers});
    }

  updateSaint(saint: Saint) {
    const body=JSON.stringify(saint);
    const headers = { 'content-type': 'application/json'};
    return this.http.put(this.baseUrl + 'admin/' + saint.name, body, {'headers':headers});
  }
  
   deleteSaint(saint: string) {
      return this.http.delete(this.baseUrl + 'admin/' + saint);
    }
}
