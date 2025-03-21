import { ShoppingCart } from 'lucide-react';
import { Link } from 'react-router';
import useCart from '../hooks/useCart';

export default function CartButton() {
  const { data: cart } = useCart();

  return (
    <Link
      to='/cart'
      className='flex justify-center items-center rounded-full p-2 gap-4 cursor-pointer relative font-dmsans'
    >
      <div className='relative'>
        <ShoppingCart color={'var(--color-darkblue)'} strokeWidth={1.75} />
        <span className='size-5 text-white flex justify-center items-center text-xs absolute -top-3 -right-3 rounded-full bg-blue-400 p-2.5'>
          {cart.items.reduce((acc, item) => acc + item.quantity, 0)}
        </span>
      </div>
      <p className='w-12 text-center text-darkblue'>${cart.subtotal}</p>
    </Link>
  );
}
