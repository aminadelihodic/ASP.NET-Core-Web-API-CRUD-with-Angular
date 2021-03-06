import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Role } from '../Model/roles-model';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class RoleService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }
  readonly url = "https://localhost:44331/api/roles/";

  public getRoles(): Observable<[]> {
    return this.http.get<Role[]>(this.url).pipe(map((res: any) => {
      return res;
    }));
  }
  getRole(id: string): Observable<Role> {
    const url = `${this.url}${id}`;
    return this.http.get<Role>(url);
  }
  addRole(role: Role): Observable<Role> {
    return this.http.post<Role>(this.url, role, this.httpOptions);
  }
  deleteRole(role:Role): Observable<Role> {
    const url = this.url;
    const newHttpOption = {...this.httpOptions,body:role}
    return this.http.delete<Role>(url, newHttpOption);
  }
  updateRole(role: Role, id: string): Observable<Role> {

    role.Id = id;
    return this.http.put<Role>(`${this.url}${id}`, role, this.httpOptions)
  }
}
