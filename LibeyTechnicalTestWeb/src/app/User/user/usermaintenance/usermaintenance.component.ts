import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { UbigeoService } from 'src/app/core/service/ubigeo/ubigeo.service';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { Router,ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {

  user: LibeyUser = {
    documentNumber: '',
    documentTypeId: 0,
    name: '',
    fathersLastName: '',
    mothersLastName: '',
    address: '',
    ubigeoCode: '',
    phone: '',
    email: '',
    password: '',
    active: true
  } as LibeyUser;
  
  documentTypes: any[] = [];
  regions: any[] = [];
  provinces: any[] = [];
  districts: any[] = [];
  isEditMode: boolean = false;

constructor(private ubigeoService: UbigeoService, 
  private libeyUserService: LibeyUserService,
  private router: Router,
  private route : ActivatedRoute,
  private location: Location) { }

  ngOnInit(): void {
    this.ubigeoService.getPublicDocumentTypes().subscribe(res => this.documentTypes = res);
    this.ubigeoService.getRegions().subscribe(res => this.regions = res);

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.loadUserData(id);
      this.isEditMode = true;
    }
  }

  loadUserData(id: string) {
  this.libeyUserService.Find(id).subscribe({
    next: (data) => {
      this.user = data; 
      
      if (this.user.regionCode) {
        this.ubigeoService.getProvinces(this.user.regionCode).subscribe(res => {
          this.provinces = res;
          
          if (this.user.provinceCode) {
            this.ubigeoService.getDistricts(this.user.provinceCode).subscribe(res => {
              this.districts = res;
            });
          }
        });
      }
    },
    error: (err) => swal.fire("Error", "No se encontró el usuario", "error")
  });
}

  Clear() {
  this.user = {
    documentNumber: '',
    documentTypeId: 0,
    name: '',
    fathersLastName: '',
    mothersLastName: '',
    address: '',
    ubigeoCode: '',
    phone: '',
    email: '',
    password: '',
    active: true
  } as LibeyUser;

  this.provinces = [];
  this.districts = [];
}

  Back() {
    this.location.back(); 
  }

  changeRegion(event: any) {
    const regionCode = event.target.value;
    this.provinces = [];
    this.districts = [];
    this.ubigeoService.getProvinces(regionCode).subscribe(res => {
      this.provinces = res;
    });
  }

  onRegionChange(region: any) {
    this.provinces = [];
    this.districts = [];
    if (region) {
      this.ubigeoService.getProvinces(region.regionCode).subscribe(res => this.provinces = res);
    }
  }

  onProvinceChange(province: any) {
    this.districts = [];
    if (province) {
      this.ubigeoService.getDistricts(province.provinceCode).subscribe(res => this.districts = res);
    }
  }

  Submit() {
    const isEdit = !!this.route.snapshot.paramMap.get('id');

    if (isEdit) {
      this.libeyUserService.Update(this.user).subscribe({
            next: () => {
                swal.fire("¡Actualizado!", "Los datos se guardaron correctamente", "success");
                this.router.navigate(['user/list']);
            },
            error: () => swal.fire("Error", "No se pudo actualizar el usuario", "error")
        });
    } else {
      this.libeyUserService.Create(this.user).subscribe({
          next: (response) => {
              swal.fire("¡Éxito!", "El usuario ha sido registrado correctamente.", "success");
              this.Clear();
          },
          error: (err) => {
              console.error(err);
              swal.fire("Error", "No se pudo registrar el usuario.", "error");
          }
      });
    }
  }
}