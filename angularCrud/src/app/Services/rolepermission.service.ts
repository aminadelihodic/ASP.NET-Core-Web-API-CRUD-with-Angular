import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { RolePermission } from '../Model/rolepermission-model';
import { catchError, map } from 'rxjs/operators';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Role } from '../Model/roles-model';
@Injectable({
  providedIn: 'root'
})
export class RolepermissionService {
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  constructor(private http: HttpClient) { }
  readonly url = "https://localhost:44331/api/roles/";

  public getRolePermissions(roleId: string): Observable<RolePermission[]> {
    return this.http.get<RolePermission[]>(this.url + roleId + '/permissions');
  }
  public getRolePermission(roleId: string) {
    const url = this.url + roleId + '/permissions';
    return this.http.get<RolePermission>(url);
  }

  addRolePermission(roleId: string, rolepermission: RolePermission): Observable<RolePermission> {
    let api = `${this.url}${roleId}/permissions/${rolepermission.PermissionId}`;
    return this.http.post<RolePermission>(api, rolepermission)
      .pipe(
        catchError(this.handleError)
      )
  }
  deleteRole(id: string): Observable<RolePermission> {
    const url = `${this.url}${id}`;

    return this.http.delete<RolePermission>(url, this.httpOptions);
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
