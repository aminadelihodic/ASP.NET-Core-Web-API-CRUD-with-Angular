import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PermissionsService } from 'src/app/Services/permissions.service';

@Component({
  selector: 'app-permission-detail',
  templateUrl: './permission-detail.component.html',
  styleUrls: ['./permission-detail.component.css']
})
export class PermissionDetailComponent implements OnInit {
  formValue!: FormGroup;
  editPermission = new FormGroup({
    Id: new FormControl(''),
    Description: new FormControl('')
  })
  constructor(private route: ActivatedRoute,
    private permissionService: PermissionsService,
    private router: Router) { }

  ngOnInit(): void {
    console.log(this.route.snapshot.params.id);
    this.permissionService.getPermission(this.route.snapshot.params.id).subscribe((result) =>
      this.editPermission = new FormGroup({
        Id: new FormControl(result['Id']),
        Description: new FormControl(result['Description'])
      })
    )
  }
  updatePermission() {
    this.permissionService.updatePermission(this.editPermission.value, this.route.snapshot.params.id).subscribe((result) =>
      console.log(result, "data updated successfully"));
    this.router.navigate(['permissions']);
  }
}
