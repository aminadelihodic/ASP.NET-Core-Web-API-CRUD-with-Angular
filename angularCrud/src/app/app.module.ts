import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CountriesComponent } from './Components/countries/countries.component';
import { CountryDetailComponent } from './Components/country-detail/country-detail.component';
import { FormsModule } from '@angular/forms';
import { CitiesComponent } from './Components/cities/cities.component';
import { PermissionsComponent } from './Components/permissions/permissions.component';
import { RolesComponent } from './Components/roles/roles.component';
import { UserComponent } from './Components/user/user.component';
import { CityDetailComponent } from './Components/city-detail/city-detail.component';
import { PermissionDetailComponent } from './Components/permission-detail/permission-detail.component';
import { RoleDetailComponent } from './Components/role-detail/role-detail.component';
import { UserDetailComponent } from './Components/user-detail/user-detail.component';
import { PermissionShowComponent } from './Components/roles/permission-show/permission-show.component';
import { RolepermissionComponent } from './Components/rolepermission/rolepermission.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './shared/authconfig.interceptor';
import { SigninComponent } from './Components/signin/signin.component';
import { SignupComponent } from './Components/signup/signup.component';
import { UserProfileComponent } from './Components/user-profile/user-profile.component';
@NgModule({
  declarations: [
    AppComponent,
    CountriesComponent,
    CountryDetailComponent,
    CitiesComponent,
    PermissionsComponent,
    RolesComponent,
    UserComponent,
    CityDetailComponent,
    PermissionDetailComponent,
    RoleDetailComponent,
    UserDetailComponent,
    PermissionShowComponent,
    RolepermissionComponent,
    SignupComponent,
    SigninComponent,
    UserProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
