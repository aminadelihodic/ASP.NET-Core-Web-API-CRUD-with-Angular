import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { City } from '../Model/city-model';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }
  readonly url = "https://localhost:44331/api/cities/";

  getCities(): Observable<City[]> {
    return this.http.get<City[]>(this.url).pipe(map((res: any) => {
      return res;
    }));
  }
  getCity(id: number): Observable<City> {
    const url = `${this.url}${id}`;
    return this.http.get<City>(url);
  }
  addCity(city: City): Observable<City> {
    return this.http.post<City>(this.url, city, this.httpOptions);
  }
  deleteCity(city:City): Observable<City> {
    const url = this.url;
    const newHttpOptions = {...this.httpOptions,body:city}
    return this.http.delete<City>(url, newHttpOptions);
  }
  updateCity(city: City, id: number): Observable<City> {
    city.Id = id;
    return this.http.put<City>(`${this.url}${id}`, city, this.httpOptions)
  }


}
