import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { User } from '../Model/user-model';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }
  readonly url = "https://localhost:44331/api/users/";

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.url).pipe(map((res: any) => {
      return res;
    }));
  }
  getUser(id: number): Observable<User> {

    const url = `${this.url}${id}`;
    return this.http.get<User>(url);
  }
  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.url, user, this.httpOptions);
  }
  deleteUser(user:User): Observable<User> {
    const url = this.url;
    const newHttpOptions = {...this.httpOptions,body:user}
    return this.http.delete<User>(url, newHttpOptions);
  }
  updateUser(user: User, id: number): Observable<User> {
    user.Id = id;
    return this.http.put<User>(`${this.url}${id}`, user, this.httpOptions)
  }
}
