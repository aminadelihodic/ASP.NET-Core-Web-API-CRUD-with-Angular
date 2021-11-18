import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { User } from 'src/app/Model/user-model';
import { UserService } from 'src/app/Services/user.service';
import { Router } from '@angular/router';
import { CitiesService } from 'src/app/Services/cities.service';
import { City } from 'src/app/Model/city-model';
import { Role } from 'src/app/Model/roles-model';
import { RoleService } from 'src/app/Services/roles.service';
@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  formValue!: FormGroup;
  users: User[] = [];
  cityList: City[] = new Array();
  roleList: Role[] = new Array();
  constructor(private formBuilder: FormBuilder, private userService: UserService
    , private router: Router,
    private cityService: CitiesService,
    private roleService: RoleService) { }

  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      FirstName: [''],
      LastName: [''],
      Username: [''],
      PasswordHash: [''],
      Email: [''],
      PhoneNumber: [''],
      CityId: 0,
      CityName: [''],
      RoleId: ['']
    })
    this.getUsers();
    this.cityService.getCities().subscribe(city => {
      this.cityList = city;
    })
    this.roleService.getRoles().subscribe(role => {
      this.roleList = role;
    })
  }
  getUsers() {
    this.userService.getUsers().subscribe(res => {
      this.users = res;
    })
  }
  add(): void {
    this.userService.addUser(this.formValue.value)
      .subscribe(c => {
        this.users.push(c);
      });
  }
  delete(user: User): void {
    alert("Deleted successfully")
    this.users = this.users.filter(h => h !== user);
    this.userService.deleteUser(user).subscribe()
  }
  edit(userId: number) {
    this.router.navigate(['/edituser', userId]);
  }

}
