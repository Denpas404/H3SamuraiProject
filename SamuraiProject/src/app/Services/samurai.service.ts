import { Injectable } from '@angular/core';
import { Samurai } from '../Models/Samurai';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SamuraiService {

  url : string = environment.apiUrl + '/samurai';

  constructor(private http: HttpClient) {}


  getAllFromApi() : Observable<Samurai[]> {
    console.log(this.url);
    return this.http.get<Samurai[]>(this.url);
  }

}
