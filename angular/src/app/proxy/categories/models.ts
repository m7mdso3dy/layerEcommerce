import type { FullAuditedEntityDto } from '@abp/ng.core';
import type { ProductDto } from '../products/models';

export interface CategoryDto extends FullAuditedEntityDto<string> {
  name?: string;
  nameAr?: string;
  description?: string;
  descriptionAr?: string;
  products: ProductDto[];
}

export interface CreateUpdateCategoryDto {
  name: string;
  nameAr: string;
  description: string;
  descriptionAr: string;
}
