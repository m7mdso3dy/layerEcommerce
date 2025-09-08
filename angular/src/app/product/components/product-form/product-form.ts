import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/proxy/products/product.service';
import { CreateUpdateProductDto, ProductDto } from 'src/app/proxy/products/models';
import { SelectModule } from 'primeng/select';
import { CategoryService } from 'src/app/proxy/categories';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, SelectModule],
  templateUrl: './product-form.html',
  styleUrl: './product-form.scss',
})
export class ProductForm implements OnInit {
  productForm!: FormGroup;
  productId?: string; // if present → edit mode
  loading = false;
  categories: { id: string; name: string }[] = [];
  fb = inject(FormBuilder);
  route = inject(ActivatedRoute);
  router = inject(Router);
  categoryService = inject(CategoryService);
  productService = inject(ProductService);

  ngOnInit(): void {
    this.buildForm();
    this.loadCategories();
    // check if editing
    this.productId = this.route.snapshot.paramMap.get('id') ?? undefined;
    if (this.productId) {
      this.loadProduct(this.productId);
    }
  }
  private loadCategories() {
    this.categoryService
      .getList({
        skipCount: 0,
        maxResultCount: 999,
      })
      .subscribe((res:any) => {

        this.categories = res.items;
      });
  }
  private buildForm() {
    this.productForm = this.fb.group({
      sku: ['', Validators.required],
      name: ['', Validators.required],
      nameAr: ['', Validators.required],
      description: [''],
      descriptionAr: [''],
      shortDescription: [''],
      shortDescriptionAr: [''],
      categoryId: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      isActive: [true, Validators.required],
    });
  }

  private loadProduct(id: string) {
    this.loading = true;
    this.productService.get(id).subscribe({
      next: (product: ProductDto) => {
        this.productForm.patchValue(product);
        this.loading = false;
      },
      error: () => {
        this.loading = false;
        // TODO: add error toast
      },
    });
  }

  save() {
    if (this.productForm.invalid) {
      this.productForm.markAllAsTouched();
      return;
    }

    const dto: CreateUpdateProductDto = this.productForm.value;

    if (this.productId) {
      // Update
      this.productService.update(this.productId, dto).subscribe({
        next: () => this.router.navigate(['/products']),
        error: () => {
          // TODO: handle error
        },
      });
    } else {
      // Create
      this.productService.create(dto).subscribe({
        next: () => this.router.navigate(['/products']),
        error: () => {
          // TODO: handle error
        },
      });
    }
  }
}
