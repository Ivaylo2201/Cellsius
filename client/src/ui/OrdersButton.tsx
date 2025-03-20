import { Package } from 'lucide-react';
import { Link } from 'react-router';

type OrdersButtonProps = {};

export default function OrdersButton({}: OrdersButtonProps) {
  return (
    <Link
      to='/orders'
      className='ml-2.5 flex bg-blue-400 hover:bg-blue-300 duration-200 transition-colors justify-center items-center rounded-full p-2 cursor-pointer relative font-dmsans'
    >
      <Package color='white' strokeWidth={1.75} />
    </Link>
  );
}
