import type { FullAuditedEntityDto } from '@abp/ng.core';
import type { CategoryDto } from '../categories/models';

export interface CreateUpdateProductDto {
  sku: string;
  name: string;
  nameAr: string;
  description: string;
  descriptionAr: string;
  shortDescription: string;
  shortDescriptionAr: string;
  categoryId: string;
  price: number;
  isActive: boolean;
}

export interface ProductDto extends FullAuditedEntityDto<string> {
  sku?: string;
  name?: string;
  nameAr?: string;
  description?: string;
  descriptionAr?: string;
  shortDescription?: string;
  shortDescriptionAr?: string;
  categoryId?: string;
  category: CategoryDto;
  price: number;
  isActive: boolean;
}
