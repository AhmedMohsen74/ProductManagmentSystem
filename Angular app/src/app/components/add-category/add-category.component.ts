import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Status } from 'src/app/models/status'; 
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})
export class AddCategoryComponent implements OnInit {

  frm!: FormGroup;
  status!: Status; 
  categoryId!: number; 

  get f() {
    return this.frm.controls;
  }

  constructor(
    private fb: FormBuilder,
    private categoryService: CategoryService,
    private route: ActivatedRoute
  ) {
    const id = this.route.snapshot.params['id'];
    this.categoryId = id;
  }

  ngOnInit(): void {
    this.frm = this.fb.group({
      id: [0], 
      name: ['', Validators.required], 
    });

    if (this.categoryId) {
      this.categoryService.GetById(this.categoryId).subscribe({
        next: (res) => {
          this.frm.patchValue({
            id: res.id,
            name: res.name,
          });
        },
        error: (err) => {
          console.log('Error fetching category data:', err);
        }
      });
    }
  }

  onPost() {
    this.status = { statusCode: 0, message: 'Processing...' };
    this.frm.patchValue({
      id: this.categoryId || 0,
    });

    this.categoryService.addUpdate(this.frm.value).subscribe({
      next: (res) => {
        this.frm.reset();
        if (res.statusCode === 1) {
          this.status = { statusCode: 1, message: 'Category saved successfully!' };
        } else {
          this.status = { statusCode: 0, message: res.message || 'An error occurred!' };
        }
      },
      error: (err) => {
        console.error('Error saving category:', err);
        this.status = { statusCode: 0, message: 'Failed to save category. Please try again.' };
      }
    });
  }
}
