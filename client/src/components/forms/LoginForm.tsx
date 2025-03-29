import { useForm } from 'react-hook-form';
import useRegister from '../../hooks/useRegister';
import { Link, useNavigate } from 'react-router';
import { RegisterData } from '../../types/RegisterData';
import { registerSchema } from '../../schemas/register.schema';
import { toast } from 'react-toastify';
import { AxiosError } from 'axios';
import Column from '../../layout/Column';
import { PasswordInput, TextInput } from '@mantine/core';
import SubmitButton from '../../ui/SubmitButton';
import { Lock, Mail } from 'lucide-react';
import { loginSchema } from '../../schemas/login.schema';
import useLogin from '../../hooks/useLogin';

export default function Register() {
  const { register, handleSubmit } = useForm<RegisterData>();
  const { mutateAsync } = useLogin();
  const navigate = useNavigate();

  const onSubmit = async (data: RegisterData) => {
    const result = loginSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message || 'Something went wrong.');
      return;
    }

    try {
      await mutateAsync(data);
      navigate('/');
      return;
    } catch (error) {
      if (error instanceof AxiosError) {
        toast.error(error.response?.data.message);
      }
    }
  };

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className='rounded-xl px-15 py-10 border border-gray-300 flex flex-col gap-8'
    >
      <h1 className='font-dmsans text-2xl font-bold text-darkblue'>
        Welcome back!
      </h1>
      <Column className='gap-3'>
        <TextInput
          size='md'
          variant='filled'
          label='Email'
          rightSectionPointerEvents='none'
          rightSection={<Mail color='var(--color-gray-400)' size={20} />}
          withAsterisk
          placeholder='example@cellsius.bg'
          styles={{
            input: {
              color: '#737374',
              backgroundColor: 'var(--color-gray-200)'
            },
            label: { color: 'var(--color-darkblue)', fontWeight: 'bold' }
          }}
          {...register('email')}
        />
        <PasswordInput
          size='md'
          variant='filled'
          label='Password'
          rightSectionPointerEvents='none'
          rightSection={<Lock color='var(--color-gray-400)' size={20} />}
          withAsterisk
          styles={{
            input: {
              color: '#737374',
              backgroundColor: 'var(--color-gray-200)'
            },
            label: { color: 'var(--color-darkblue)', fontWeight: 'bold' }
          }}
          {...register('password')}
        />
      </Column>
      <Column className='items-center gap-3'>
        <p className='text-darkblue font-semibold'>
          Don't have an account? Register{' '}
          <Link className='text-blue-400' to='/auth/register'>
            here
          </Link>
        </p>
        <SubmitButton>Login</SubmitButton>
      </Column>
    </form>
  );
}
