import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Permission } from 'src/app/Model/permissions-model';
import { PermissionsService } from 'src/app/Services/permissions.service';
import { Router } from '@angular/router';
import { RolePermission } from 'src/app/Model/rolepermission-model';
@Component({
  selector: 'app-permissions',
  templateUrl: './permissions.component.html',
  styleUrls: ['./permissions.component.css']
})
export class PermissionsComponent implements OnInit {
  roleList: RolePermission[] = new Array();
  formValue!: FormGroup;
  permissions: Permission[] = [];
  constructor(private formBuilder: FormBuilder, private permissionService: PermissionsService, private router: Router) { }

  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      Id: [''],
      Description: ['']
    })
    this.getPermission();
  }
  getPermission() {
    this.permissionService.getPermissions().subscribe(res => {
      this.permissions = res;
    })
  }
  add(): void {
    this.permissionService.addPermission(this.formValue.value)
      .subscribe(c => {
        this.permissions.push(c);
      });
  }
  delete(permission: Permission): void {
    alert("Deleted successfully")
    this.permissions = this.permissions.filter(h => h !== permission);
    this.permissionService.deletePermission(permission).subscribe()
  }
  edit(permissionId: string) {
    this.router.navigate(['/update', permissionId]);
  }

}
