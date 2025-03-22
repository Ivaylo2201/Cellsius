import { Minus, Plus } from 'lucide-react';

type QuantityControlProps = {
  quantity: number;
  onIncrement: () => void;
  onDecrement: () => void;
};

export default function QuantityControl({
  quantity,
  onIncrement,
  onDecrement
}: QuantityControlProps) {
  return (
    <div className='flex flex-col gap-2 md:flex-row justify-center items-center font-dmsans'>
      <button
        onClick={onDecrement}
        disabled={quantity === 1}
        className='cursor-pointer bg-blue-400 disabled:bg-gray-400 rounded-full p-2 text-white'
      >
        <Minus size={16} strokeWidth={2.75} />
      </button>

      <span className='w-6 text-center'>
        <p className='text-xl font-semibold text-darkblue'>{quantity}</p>
      </span>
      
      <button
        onClick={onIncrement}
        disabled={quantity === 10}
        className='cursor-pointer bg-blue-400 disabled:bg-gray-400 rounded-full p-2 text-white'
      >
        <Plus size={16} strokeWidth={2.75} />
      </button>
    </div>
  );
}
