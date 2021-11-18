import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Country } from '../Model/country-model';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }
  readonly url = "https://localhost:44331/api/countries/";

  getCountries(): Observable<Country[]> {
    return this.http.get<Country[]>(this.url).pipe(map((res: any) => {
      return res;
    }));
  }
  getCountry(id: number): Observable<Country> {

    const url = `${this.url}${id}`;
    return this.http.get<Country>(url);
  }
  addCountry(country: Country): Observable<Country> {
    return this.http.post<Country>(this.url, country, this.httpOptions);
  }
  deleteCountry(country:Country): Observable<Country> {
    const url = `${this.url}`;
    const newHttpOptions = {...this.httpOptions,body:country}
    return this.http.delete<Country>(url, newHttpOptions);
  }

  updateCountry(country: Country, id: number): Observable<Country> {
    country.Id = id;
    return this.http.put<Country>(`${this.url}${id}`, country, this.httpOptions)
  }
}

