import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RoleService } from 'src/app/Services/roles.service';

@Component({
  selector: 'app-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.css']
})
export class RoleDetailComponent implements OnInit {
  formValue!: FormGroup;
  editRole = new FormGroup({
    Id: new FormControl(this.route.snapshot.params.id ?? ''),
    Description: new FormControl('')
  })
  constructor(private route: ActivatedRoute,
    private roleService: RoleService,
    private router: Router) { }

  ngOnInit(): void {
    console.log(this.route.snapshot.params.id);
    this.roleService.getRole(this.route.snapshot.params.id).subscribe((result) =>
      this.editRole = new FormGroup({
        Id: new FormControl(result['Id']),
        Description: new FormControl(result['Description'])
      })
    )
  }

  updateRole() {
    this.roleService.updateRole(this.editRole.value, this.route.snapshot.params.id).subscribe((result) =>
      console.log(result, "data updated successfully"));
    this.router.navigate(['roles']);
  }
}
