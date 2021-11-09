import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Role } from 'src/app/Model/roles-model';
import { RoleService } from 'src/app/Services/roles.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-roles',
  templateUrl: './roles.component.html',
  styleUrls: ['./roles.component.css']
})
export class RolesComponent implements OnInit {
  formValue!: FormGroup;
  roles: Role[] = [];
  constructor(private formBuilder: FormBuilder, private roleService: RoleService,
    private router: Router) { }

  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      Id: [''],
      Description: ['']
    })
    this.getRoles();
  }
  getRoles() {
    this.roleService.getRoles().subscribe(res => {
      this.roles = res;
    })
  }
  add(): void {
    this.roleService.addRole(this.formValue.value)
      .subscribe(c => {
        this.roles.push(c);
      });
  }
  delete(role: Role): void {
    alert("Deleted successfully")
    this.roles = this.roles.filter(h => h !== role);
    this.roleService.deleteRole(role.Id).subscribe()
  }
  show(id: string) {
    window.location.href = "roles/" + id;
  }
  edit(roleId: string) {
    this.router.navigate(['/roleupdate', roleId]);
  }
}


