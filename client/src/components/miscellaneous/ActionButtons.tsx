import { useAuthStore } from '../../stores/authStore';
import Button from '../../ui/Button';
import CartButton from '../../ui/CartButton';
import OrdersButton from '../../ui/OrdersButton';

export default function ActionButtons() {
  const { isAuthenticated } = useAuthStore();

  if (!isAuthenticated) {
    return (
      <div className='flex gap-4'>
        <Button
          to='/auth/register'
          className='bg-blue-400 hover:bg-blue-300 text-white'
        >
          Register
        </Button>
        <Button
          to='/auth/login'
          className='bg-darkblue hover:bg-light-darkblue text-white'
        >
          Login
        </Button>
      </div>
    );
  }

  return (
    <div className='flex gap-4'>
      <Button
        to='/phone/add'
        className='bg-blue-400 hover:bg-blue-300 text-white'
      >
        Add Phone
      </Button>
      <OrdersButton />
      <CartButton />
    </div>
  );
}
