import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Permission } from '../Model/permissions-model';
import { map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class PermissionsService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }
  readonly url = "https://localhost:44331/api/permissions/";

  public getPermissions(): Observable<Permission[]> {
    return this.http.get<Permission[]>(this.url).pipe(map((res: any) => {
      return res;
    }));
  }
  getPermission(id: string): Observable<Permission> {
    const url = `${this.url}${id}`;
    return this.http.get<Permission>(url);
  }
  addPermission(permission: Permission): Observable<Permission> {
    return this.http.post<Permission>(this.url, permission, this.httpOptions);
  }
  deletePermission(permission:Permission): Observable<Permission> {
    const url = this.url;
    const newHttpOption = {...this.httpOptions,body:permission}
    return this.http.delete<Permission>(url, newHttpOption);
  }
  updatePermission(permission: Permission, id: string): Observable<Permission> {
    permission.Id = id;
    return this.http.put<Permission>(`${this.url}${id}`, permission, this.httpOptions)
  }
}
