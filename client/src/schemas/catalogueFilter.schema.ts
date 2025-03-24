import { z } from 'zod';

export const CatalogueFilterSchema = z.object({
  brand: z.string().nullable(),
  models: z.array(z.object({ name: z.string() })),
  color: z.string().nullable(),
  minPrice: z.number(),
  maxPrice: z.number(),
  sortBy: z.string().nullable(),
  order: z.string().nullish(),
});
