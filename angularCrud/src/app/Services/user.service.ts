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
    return this.http.get<User[]>(`${this.url}get_user`).pipe(map((res: any) => {
      return res;
    }));
  }
  getUser(id: number): Observable<User> {

    const url = `${this.url}${id}`;
    return this.http.get<User>(url);
  }
  addUser(user: User): Observable<User> {
    return this.http.post<User>(`${this.url}add_user`, user, this.httpOptions);
  }
  deleteUser(id: number): Observable<User> {
    const url = `${this.url}${id}`;

    return this.http.delete<User>(url, this.httpOptions);
  }
  updateUser(user: User, id: number): Observable<User> {
    user.Id = id;
    return this.http.put<User>(`${this.url}${id}`, user, this.httpOptions)
  }
}
