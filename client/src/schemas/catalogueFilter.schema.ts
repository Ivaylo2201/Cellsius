import { z } from 'zod';

export const CatalogueFilterSchema = z.object({
  brand: z.string(),
  models: z.array(z.object({ name: z.string() })),
  color: z.string(),
  minPrice: z.number(),
  maxPrice: z.number(),
  sort: z.literal('asc').or(z.literal('desc')),
});
