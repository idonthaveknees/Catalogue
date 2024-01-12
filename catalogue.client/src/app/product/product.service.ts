import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Product } from './product.model';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  private apiPath = 'https://localhost:7026/api/products';

  private productAddedSource = new EventEmitter<Product>();
  productAdded$ = this.productAddedSource.asObservable();

  constructor(private http: HttpClient) {}

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiPath);
  }

  addProduct(product: Product): Observable<Product> {
    return this.http.post<Product>(this.apiPath, product).pipe(
      tap((newProduct: Product) => this.productAddedSource.emit(newProduct))
    );
  }
}
