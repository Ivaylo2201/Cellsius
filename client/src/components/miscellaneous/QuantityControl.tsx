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
    <div className='min-w-24 flex justify-center items-center font-dmsans mr-6 g-red-500'>
      <button
        onClick={onDecrement}
        disabled={quantity === 1}
        className='cursor-pointer bg-blue-400 disabled:bg-gray-400 rounded-full p-2 text-white'
      >
        <Minus size={16} strokeWidth={2.75} />
      </button>
      <span className='w-6 mx-4 text-center'>
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
