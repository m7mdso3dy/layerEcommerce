import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { ProductDto, ProductService } from 'src/app/proxy/products';
import { Router } from '@angular/router';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-prouct-list',
  standalone: true,
  imports: [CommonModule, TableModule, ButtonModule],
  templateUrl: './prouct-list.html',
  styleUrl: './prouct-list.scss',
})
export class ProuctList implements OnInit {
  productService = inject(ProductService);
  products: ProductDto[] = [];
  router = inject(Router);
  confirmation = inject(ConfirmationService);
  ngOnInit(): void {
    this.loadProducts();
  }

  loadProducts() {
    this.productService
      .getList({
        sorting: '',
        skipCount: 0,
        maxResultCount: 20,
      })
      .subscribe(res => {
        this.products = res.items ?? [];
      });
  }

  createProduct() {
    console.log('Create new product');
    this.router.navigate(['products/create']);
  }

  editProduct(product: ProductDto) {
    console.log('Edit product', product);
    this.router.navigate([`products/update/${product.id}`]);
  }

  deleteProduct(product: ProductDto) {
    console.log('Delete product', product);
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe(status => {
      if (status === Confirmation.Status.confirm) {
        this.productService.delete(product.id).subscribe(() => {
          this.loadProducts();
        });
      }
    });
    // TODO: call service delete and refresh list
  }
}
