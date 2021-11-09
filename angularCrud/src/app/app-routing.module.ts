import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CountriesComponent } from './Components/countries/countries.component';
import { CountryDetailComponent } from './Components/country-detail/country-detail.component';
import { CitiesComponent } from './Components/cities/cities.component';
import { PermissionsComponent } from './Components/permissions/permissions.component';
import { RolesComponent } from './Components/roles/roles.component';
import { UserComponent } from './Components/user/user.component';
import { PermissionDetailComponent } from './Components/permission-detail/permission-detail.component';
import { RoleDetailComponent } from './Components/role-detail/role-detail.component';
import { UserDetailComponent } from './Components/user-detail/user-detail.component';
import { PermissionShowComponent } from './Components/roles/permission-show/permission-show.component';
import { RolepermissionComponent } from './Components/rolepermission/rolepermission.component';
import { CityDetailComponent } from './Components/city-detail/city-detail.component';
import { SigninComponent } from './Components/signin/signin.component';
import { SignupComponent } from './Components/signup/signup.component';
import { UserProfileComponent } from './Components/user-profile/user-profile.component';
import { AuthGuard } from "./shared/auth.guard";

const routes: Routes = [
  { path: '', redirectTo: '/log-in', pathMatch: 'full' },
  { path: 'log-in', component: SigninComponent },
  { path: 'sign-up', component: SignupComponent },
  { path: 'user-profile/:id', component: UserProfileComponent, canActivate: [AuthGuard] },
  { path: 'countries', component: CountriesComponent },
  { path: 'edit/:id', component: CountryDetailComponent },
  { path: 'cities', component: CitiesComponent },
  { path: 'cityedit/:id', component: CityDetailComponent },
  { path: 'permissions', component: PermissionsComponent },
  { path: 'update/:id', component: PermissionDetailComponent },
  { path: 'roles', component: RolesComponent },
  { path: 'roles/:id', component: PermissionShowComponent },
  { path: 'roleupdate/:id', component: RoleDetailComponent },
  { path: 'users', component: UserComponent },
  { path: 'edituser/:id', component: UserDetailComponent },
  { path: 'rolepermissions', component: RolepermissionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
