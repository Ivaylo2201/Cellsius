import { z } from 'zod';
import { addPhoneSchema } from '../schemas/addPhone.schema';

export type AddPhoneData = z.infer<typeof addPhoneSchema>;
