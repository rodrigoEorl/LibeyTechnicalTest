import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { UbigeoService } from 'src/app/core/service/ubigeo/ubigeo.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { Router } from '@angular/router';
@Component({
	selector: "app-userlist",
	templateUrl: "./userlist.component.html",
	styleUrls: ["./userlist.component.css"],
})
export class UserlistComponent implements OnInit {
  users: any[] = [];
  filterText: string = "";

  constructor(private userService: LibeyUserService, private router: Router) {}

  ngOnInit(): void {
    this.search();
  }

  search() {
    this.userService.GetAll(this.filterText).subscribe(res => this.users = res);
  }

  edit(documentNumber: string) {
    this.router.navigate(['user/maintenance', documentNumber]);
  }

  delete(documentNumber: string) {
    swal.fire({
      title: '¿Estás seguro?',
      text: "¡No podrás revertir esto!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sí, borrar'
    }).then((result) => {
      if (result.isConfirmed) {
        this.userService.Delete(documentNumber).subscribe(() => {
          this.search();
          swal.fire('Borrado', 'Usuario eliminado', 'success');
        });
      }
    });
  }
}