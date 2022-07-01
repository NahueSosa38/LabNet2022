import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Categoria } from '../models/categorias';

@Injectable({
  providedIn: 'root'
})
export class CategoriasService {
  [x: string]: any;
  
  constructor(private http: HttpClient) { }

  crearCat(request : Categoria): Observable<any>{

    let endpoint = 'api/CategoriesApi'

    return this.http.post(environment.apiCategorias + endpoint, request);   

  }

  traerCategoriasTs(): Observable<Array<Categoria>>{

    let endpoint = 'api/CategoriesApi'
    let url = environment.apiCategorias + endpoint;
    return this.http.get<Array<Categoria>>(url);

  }

  borrarCat(id: number) {

    let endpoint = 'api/CategoriesApi/'
    let url = environment.apiCategorias + endpoint;
    return this.http.delete<Array<Categoria>>(url + id);
  
  }

  modificarCategoria(categoriesRequest: Categoria): Observable<any> {

    let endpoint = 'api/CategoriesApi/'   
    let url = environment.apiCategorias + endpoint;
    return this.http.put<Array<Categoria>>(url + categoriesRequest.Id, categoriesRequest);
   
  }
}
