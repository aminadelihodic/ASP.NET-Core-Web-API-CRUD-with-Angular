import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { City } from 'src/app/Model/city-model';
import { Role } from 'src/app/Model/roles-model';
import { CitiesService } from 'src/app/Services/cities.service';
import { RoleService } from 'src/app/Services/roles.service';
import { UserService } from 'src/app/Services/user.service';
@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  formValue!: FormGroup;
  editUser = new FormGroup({
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    Username: new FormControl(''),
    PasswordHash: new FormControl(''),
    Email: new FormControl(''),
    PhoneNumber: new FormControl(''),
    CityId: new FormControl(''),
    CityName: new FormControl(''),
    RoleId: new FormControl('')
  })
  cityList: City[] = new Array();
  roleList: Role[] = new Array();
  constructor(private route: ActivatedRoute,
    private userservice: UserService,
    private router: Router,
    private cityService: CitiesService,
    private roleService: RoleService) { }

  ngOnInit(): void {
    console.log(this.route.snapshot.params.id);
    this.userservice.getUser(this.route.snapshot.params.id).subscribe((result) =>
      this.editUser = new FormGroup({
        FirstName: new FormControl(result['FirstName']),
        LastName: new FormControl(result['LastName']),
        Username: new FormControl(result['Username']),
        PasswordHash: new FormControl(result['PasswordHash']),
        Email: new FormControl(result['Email']),
        PhoneNumber: new FormControl(result['PhoneNumber']),
        CityId: new FormControl(result['CityId']),
        CityName: new FormControl(result['CityName']),
        RoleId: new FormControl(result['RoleId'])
      })
    )
    
    this.cityService.getCities().subscribe(city => {
      this.cityList = city;
    })
    this.roleService.getRoles().subscribe(role => {
      this.roleList = role;
    })
  }
  updateUser() {
    this.userservice.updateUser(this.editUser.value, this.route.snapshot.params.id).subscribe((result) =>
      console.log(result, "data updated successfully"));
    this.router.navigate(['users']);
  }

}
