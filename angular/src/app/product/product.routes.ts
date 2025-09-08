import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./components/prouct-list/prouct-list').then(c => c.ProuctList),
  },
  {
    path:'create',
    loadComponent: () => import('./components/product-form/product-form').then(c => c.ProductForm),
  },
  {
    path:'update/:id',
    loadComponent: () => import('./components/product-form/product-form').then(c => c.ProductForm),
  }
];
