import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddProductComponent } from './components/add-product/add-product.component';
import { ProductsComponent } from './components/products/products.component';
import { AddCategoryComponent } from './components/add-category/add-category.component';
import { CategoriesComponent } from './components/categories/categories.component';

const routes: Routes = [
  {path:'add-product',component:AddProductComponent},
  {path:'update-product/:id',component:AddProductComponent},
  {path:'products',component:ProductsComponent},
  {path:'add-category',component:AddCategoryComponent},
  { path:'update-category/:id', component: AddCategoryComponent }, 
  {path:'categories',component:CategoriesComponent},
  {path:'',redirectTo:'/products',pathMatch:'full'}
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
