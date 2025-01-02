import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product.service';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/services/category.service';
import { Category } from 'src/app/models/category';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Product[] = [];  
  categories: Category[] = []; 
  loading: boolean = false;

  getProducts(term: string = ''): void {
    this.loading = true;
    this.productService.getAll(term).subscribe({
      next: (res) => {
        this.products = res;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
      },
    });
  }

  search(term: string): void {
    this.getProducts(term);
  }

  edit(id: number): void {
    this.router.navigate(['/update-product', id]); // Navigate to the update-product route
  }
  delete(id: number, index: number): void {
    if (window.confirm("Are you sure to delete?")) {
      this.productService.delete(id).subscribe({
        next: (res) => {
          if (res.statusCode == 1) {
            this.products.splice(index, 1);
          } else {
            console.log(res.message);
          }
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }

  loadProducts() {
    this.loading = true;
    this.productService.getAll().subscribe((products) => {
      this.products = products;
      this.loading = false;
    });
  }

  getCategoryNameById(categoryId: number): string {
    const category = this.categories.find(cat => cat.id === categoryId);
    return category?.name || 'Unknown';
  }

  constructor(private productService: ProductService, private categoryService: CategoryService, private router: Router) { }

  ngOnInit(): void {
    this.getProducts();
    this.loadCategories();
  }

  private loadCategories() {
    this.categoryService.getAll().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (err) => {
        console.error("Error loading categories", err);
      }
    });
  }
}
