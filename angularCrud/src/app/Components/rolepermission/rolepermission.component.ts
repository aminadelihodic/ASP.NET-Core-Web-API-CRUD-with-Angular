import { Component, OnInit } from '@angular/core';
import { RolePermission } from 'src/app/Model/rolepermission-model';
import { RolepermissionService } from 'src/app/Services/rolepermission.service';

@Component({
  selector: 'app-rolepermission',
  templateUrl: './rolepermission.component.html',
  styleUrls: ['./rolepermission.component.css']
})
export class RolepermissionComponent implements OnInit {
  rolepermissions: RolePermission[] = [];
  //RolePermission!:any;
  constructor(private rolepermissionService: RolepermissionService) { }

  ngOnInit(): void {
  }
  public getRolePermission(roleId: string) {
    console.log(roleId);
    return this.rolepermissionService.getRolePermissions(roleId).subscribe(rolepermission =>
      this.rolepermissions = rolepermission
    )

  }
}
