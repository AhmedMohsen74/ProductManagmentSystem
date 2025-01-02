import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Category } from '../models/category';
import { Product } from '../models/product';
import { Status } from '../models/status';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private baseUrl=environment.baseUrl+'/category';
  constructor(private http:HttpClient) {}

   addUpdate(category:Category){
    return this.http.post<Status>(this.baseUrl+'/addupdate',category);
   }

   GetById(id:number){
    return this.http.get<{ id: number; name: string }>(this.baseUrl+'/getbyid/'+id);

   }

   getAll(name: string = ''): Observable<Category[]> {
    const url = `${this.baseUrl}/GetAll?name=${name}`;
    return this.http.get<Category[]>(url);
  }
  
   delete(id:number){
    return this.http.delete<Status>(this.baseUrl+'/delete/'+id);
   }



}