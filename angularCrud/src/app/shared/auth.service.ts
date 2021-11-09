import { Injectable } from '@angular/core';
import { Login } from '../Model/login-model';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { User } from '../Model/user-model';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  endpoint: string = 'https://localhost:44331/api/login';

  headers = new HttpHeaders().set('Content-Type', 'application/json');
  currentUser = {};

  constructor(
    private http: HttpClient,
    public router: Router
  ) { }

  signUp(login: Login): Observable<Login> {
    let api = `${this.endpoint}/Registration`;
    return this.http.post<Login>(api, login)
      .pipe(
        catchError(this.handleError)
      )
  }


  signIn(login: Login) {

    return this.http.post<Login>(`${this.endpoint}/signin/${login.Username}/${login.Password}`, login)
      .subscribe((res: Login) => {
        localStorage.setItem('access_token', res.Token)
        this.getUserProfile(res.Id).subscribe((res) => {
          this.currentUser = res;
          this.router.navigate(['countries']);
        })
      })
  }

  getToken() {
    return localStorage.getItem('access_token');
  }

  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
    return (authToken !== null) ? true : false;
  }

  doLogout() {
    let removeToken = localStorage.removeItem('access_token');
    if (removeToken == null) {
      this.router.navigate(['log-in']);
    }
  }


  getUserProfile(id: string | null): Observable<Login> {
    let api = `${this.endpoint}/user-profile/${id}`;
    return this.http.get<Login>(api, { headers: this.headers }).pipe(
      map((res: Login) => {
        return res || {}
      }),
      catchError(this.handleError)
    )
  }


  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {

      msg = error.error.message;
    } else {

      msg = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }
}