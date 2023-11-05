import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Mascota } from '../models/mascota';

@Injectable({
  providedIn: 'root'
})
export class MascotaService {

  constructor(private http:HttpClient) { }

  url:string = "https://localhost:7237/api/Mascota";

  getMascota(){
    return this.http.get(this.url);
  }
  
  addMascota(mascota:Mascota):Observable<Mascota>{
    return this.http.post<Mascota>(this.url, mascota);
  }

  updateMascota(id:number,mascota:Mascota):Observable<Mascota>{
    return this.http.put<Mascota>(this.url + `/${id}`,mascota);
  }

  deleteMascota(id:number){
    return this.http.delete(this.url + `/${id}`);
  }
}
