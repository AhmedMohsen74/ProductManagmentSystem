import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Product } from '../models/product';
import { Status } from '../models/status';
import { map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private baseUrl=environment.baseUrl+'/product';
  constructor(private http:HttpClient) {}

   addUpdate(product:Product){
    return this.http.post<Status>(this.baseUrl+'/addupdate',product);
   }

   getById(id: number) {
    return this.http.get<Product>(`${this.baseUrl}/getbyid/${id}`).pipe(
      map((res) => {
        res.createdDate = res.createdDate ? new Date(res.createdDate) : null; 
        return res;
      })
    );
  }
  
   getAll(name: string = ''): Observable<Product[]> {
    const url = `${this.baseUrl}/GetAll?name=${name}`;
    return this.http.get<Product[]>(url);
  }
  

   delete(id:number){
    return this.http.delete<Status>(this.baseUrl+'/delete/'+id);
   }
}