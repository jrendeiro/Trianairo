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

   getSaints(): Observable<Saint[]> {
     let params = new HttpParams();
     return this.http.get<Saint[]>(this.baseUrl + 'saintsApi');
    }
}
