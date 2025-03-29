import { z } from 'zod';

export const addPhoneSchema = z.object({
  brand: z.string({ required_error: 'Brand is required. ' }),
  model: z.string({ required_error: 'Model is required. ' }),
  color: z.string({ required_error: 'Color is required. ' }),
  price: z.number({ required_error: 'Price is required. ' }),
  memory: z.number({ required_error: 'Memory is required. ' }),
  image: z.instanceof(File)
});
