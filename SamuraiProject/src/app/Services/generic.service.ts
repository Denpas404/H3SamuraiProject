import { Injectable } from '@angular/core';
import { Samurai } from '../Models/Samurai';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GenericService<Tmodel> {

  url : string = environment.apiUrl ;

  constructor(private http: HttpClient) {}


  /**
   * Retrieves all data from the API.
   * Return An Observable that emits an array of Tmodel objects.
   * sajædæalks
   */
  getAllFromApi(choice: string) : Observable<Tmodel[]> {
    console.log(this.url + '/' + choice);
    return this.http.get<Tmodel[]>(this.url + '/' + choice);
  }

deletebyId(id: number, choice: string) : boolean {
  this.http.delete(this.url + '/' + choice + '/' + id);
  return true;
}

}
