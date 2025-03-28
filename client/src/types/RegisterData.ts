import { z } from 'zod';
import { registerSchema } from '../schemas/register.schema';

export type RegisterData = z.infer<typeof registerSchema>;
