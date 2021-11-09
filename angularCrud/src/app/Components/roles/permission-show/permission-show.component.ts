import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RolePermission } from 'src/app/Model/rolepermission-model';
import { RolepermissionService } from 'src/app/Services/rolepermission.service';
import { Permission } from 'src/app/Model/permissions-model';
import { PermissionsService } from 'src/app/Services/permissions.service';
import { Role } from 'src/app/Model/roles-model';
import { RoleService } from 'src/app/Services/roles.service';
import { resetFakeAsyncZone } from '@angular/core/testing';

@Component({
  selector: 'app-permission-show',
  templateUrl: './permission-show.component.html',
  styleUrls: ['./permission-show.component.css']
})
export class PermissionShowComponent implements OnInit {
  rolePermissions: RolePermission[] = [];
  permissionList: Permission[] = new Array();
  roleList!: Role;
  formValue = new FormGroup({
    RoleId: new FormControl(this.activeRouter.snapshot.params.id ?? ''),
    PermissionId: new FormControl('')
  })
  constructor(private rolepermissionService: RolepermissionService,
    private activeRouter: ActivatedRoute,
    private permissionService: PermissionsService,
    private roleService: RoleService
  ) { }

  ngOnInit(): void {
    this.getPermissions();
    this.permissionService.getPermissions().subscribe(permission => {
      this.permissionList = permission;
    })
    this.roleService.getRole(this.activeRouter.snapshot.params.id).subscribe(res => {
      this.roleList = res;
    })
  }
  getPermissions() {
    this.rolepermissionService.getRolePermissions(this.activeRouter.snapshot.params.id).subscribe(res => {
      this.rolePermissions = res;
    })
  }
  add() {
    console.log(this.activeRouter.snapshot.params.id)
    this.rolepermissionService.addRolePermission(this.activeRouter.snapshot.params.id, this.formValue.value).subscribe((res) => {
      this.formValue.reset();
    }
    )
  }
}


