import { z } from 'zod';
import { loginSchema } from '../schemas/login.schema';

export type LoginData = z.infer<typeof loginSchema>;
