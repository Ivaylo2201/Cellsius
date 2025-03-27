import { z } from 'zod';

export const registerSchema = z
  .object({
    email: z
      .string({ required_error: 'Email is required. ' })
      .email({ message: 'Invalid email.' }),
    username: z.string({ required_error: 'Username is required. ' }).min(3),
    password: z.string({ required_error: 'Password is required. ' }).min(8),
    passwordConfirmation: z
      .string({ required_error: 'Password confirmation is required. ' })
      .min(8)
  })
  .refine((data) => data.password === data.passwordConfirmation, {
    message: 'Passwords do not match',
    path: ['passwordConfirmation']
  });
