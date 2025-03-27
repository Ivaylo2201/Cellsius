import { PasswordInput, TextInput } from '@mantine/core';
import Page from '../layout/Page';
import { useForm } from 'react-hook-form';
import { RegisterData } from '../types/Register';
import SubmitButton from '../ui/SubmitButton';
import Column from '../layout/Column';
import Centered from '../layout/Centered';
import useRegister from '../hooks/useRegister';
import { AxiosError } from 'axios';
import { toast } from 'react-toastify';
import { registerSchema } from '../schemas/register.schema';
import { useNavigate } from 'react-router';

type RegisterPageProps = {};

export default function RegisterPage({}: RegisterPageProps) {
  const { register, handleSubmit } = useForm<RegisterData>();
  const { mutateAsync } = useRegister();
  const navigate = useNavigate();

  const onSubmit = async (data: RegisterData) => {
    const result = registerSchema.safeParse(data);
    
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
    <Page>
      <form
        onSubmit={handleSubmit(onSubmit, (errors) => {
          console.log(errors);
        })}
        className='border border-gray-200 shadow-xl rounded-xl p-10'
      >
        <Column>
          <TextInput
            variant='filled'
            label='Email'
            withAsterisk
            placeholder='example@cellsius.bg'
            {...register('email')}
          />
          <TextInput
            variant='filled'
            label='Username'
            withAsterisk
            placeholder='John_Doe'
            {...register('username')}
          />
          <PasswordInput
            variant='filled'
            label='Password'
            withAsterisk
            {...register('password')}
          />
          <PasswordInput
            variant='filled'
            label='Password confirmation'
            withAsterisk
            {...register('passwordConfirmation')}
          />
        </Column>
        <Centered>
          <SubmitButton>Register</SubmitButton>
        </Centered>
      </form>
    </Page>
  );
}
