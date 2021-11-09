import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/Services/user.service';
@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  formValue!: FormGroup;
  editUser = new FormGroup({
    FirstName: new FormControl('')
  })
  constructor(private route: ActivatedRoute,
    private userservice: UserService,
    private router: Router) { }

  ngOnInit(): void {
    console.log(this.route.snapshot.params.id);
    this.userservice.getUser(this.route.snapshot.params.id).subscribe((result) =>
      this.editUser = new FormGroup({
        FirstName: new FormControl(result['FirstName'])
      })
    )
  }
  updateUser() {
    this.userservice.updateUser(this.editUser.value, this.route.snapshot.params.id).subscribe((result) =>
      console.log(result, "data updated successfully"));
    this.router.navigate(['users']);
  }

}
