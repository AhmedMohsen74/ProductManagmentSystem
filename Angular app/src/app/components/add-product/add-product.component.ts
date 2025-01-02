import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Category } from 'src/app/models/category';
import { Status } from 'src/app/models/status';
import { CategoryService } from 'src/app/services/category.service';
import { ProductService } from 'src/app/services/product.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css'],
  providers: [DatePipe]  
})
export class AddProductComponent implements OnInit {

  frm!: FormGroup;
  status!: Status;
  categories!: Category[]; 
  productId!: number;

  get f() {
    return this.frm.controls; 
  }

  onPost() {
    this.status = { statusCode: 0, message: 'wait..' };
    
    const productData = { ...this.frm.value };
  
    if (!productData.id) {
      productData.id = this.productId; 
    }
  
    this.productService.addUpdate(productData).subscribe({
      next: (res) => {
        this.status = res;
        if (this.status.statusCode == 1) {
          this.frm.reset();
        }
      },
      error: (err) => {
        console.log(err);
        if (err.status === 400 && err.error.errors) {
          console.log("Validation Errors:", err.error.errors);
        }
      }
    });
    
  }

  //     downloading APIs
  private getCategories() {
    this.categoryService.getAll().subscribe({
      next: (res) => {
        this.categories = res;
        console.log(this.categories);
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  constructor(
    private fb: FormBuilder,
    private categoryService: CategoryService,
    private productService: ProductService,
    private route: ActivatedRoute,
    private datePipe: DatePipe,
    private router: Router 
  ) { 
    const id = this.route.snapshot.params['id']; 
    if (id) {
      this.productId = id;
      this.productService.getById(id).subscribe({
        next: (res) => {
          this.frm.patchValue(res); 
        },
        error: (err) => {
          console.log(err); 
        }
      });
    }
  }

  ngOnInit(): void {
    this.frm = this.fb.group({
      'id': [0],
      'name': ['', Validators.required],
      'description': ['', Validators.required],
      'categoryId': [0, Validators.required],
      'price': [0, Validators.required],
      'createdDate': [null]  
    });
    this.getCategories();

    const id = this.route.snapshot.params['id'];

    if (id) {
      // If editing, pre-fill the form
      this.productService.getById(id).subscribe((product: any) => {
        this.frm.patchValue({
          id: product.id,
          name: product.name,
          description: product.description,
          price: product.price,
          categoryId: product.categoryId
        });
      });
    }
    if (id) {
      this.productId = id;
      this.productService.getById(id).subscribe({
        next: (res) => {
          res.createdDate = null; 
          this.frm.patchValue(res);
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  }
}
