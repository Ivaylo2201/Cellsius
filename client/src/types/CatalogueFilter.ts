import { z } from 'zod';
import { CatalogueFilterSchema } from '../schemas/catalogueFilter.schema';

export type CatalogueFilter = z.infer<typeof CatalogueFilterSchema>;
