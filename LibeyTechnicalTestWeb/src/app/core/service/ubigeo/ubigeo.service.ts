import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
@Injectable({
    providedIn: "root",
})
export class UbigeoService {
    constructor(private http: HttpClient) {}

    getPublicDocumentTypes(): Observable<any[]> {
        return this.http.get<any[]>(`${environment.pathLibeyTechnicalTest}Ubigeo/document-types`);
    }

    getRegions(): Observable<any[]> {
        return this.http.get<any[]>(`${environment.pathLibeyTechnicalTest}Ubigeo/regions`);
    }

    getProvinces(regionCode: string): Observable<any[]> {
        return this.http.get<any[]>(`${environment.pathLibeyTechnicalTest}Ubigeo/provinces/${regionCode}`);
    }

    getDistricts(provinceCode: string): Observable<any[]> {
        return this.http.get<any[]>(`${environment.pathLibeyTechnicalTest}Ubigeo/districts/${provinceCode}`);
    }
}