import { useState } from 'react';
import { X } from 'lucide-react';
import { Item } from '../../types/Item';
import QuantityControl from '../miscellaneous/QuantityControl';
import useUpdateQuantity from '../../hooks/useUpdateQuantity';
import useRemoveItem from '../../hooks/useRemoveItem';

export default function ItemCard({ id, phone, quantity, price }: Item) {
  const [selectedQuantity, setSelectedQuantity] = useState<number>(quantity);
  const { mutateAsync: updateQuantity } = useUpdateQuantity(
    id,
    selectedQuantity
  );
  const { mutateAsync: removeItem } = useRemoveItem();

  const imageUrl = `${import.meta.env.VITE_IMAGE_ROOT_URL}${phone.imagePath}`;

  const handleQuantityIncrement = async () => {
    setSelectedQuantity((q) => (q + 1 > 10 ? 10 : q + 1));
    await updateQuantity();
  };

  const handleQuantityDecrement = async () => {
    setSelectedQuantity((q) => (q - 1 <= 0 ? 1 : q - 1));
    await updateQuantity();
  };

  return (
    <div className='flex justify-between border border-gray-200 rounded-xl py-6 pr-8.5 font-dmsans relative'>
      <img
        className='h-32 object-cover rounded-lg'
        src={imageUrl}
        alt={`Image of ${phone.brand} ${phone.model}`}
      />
      <section className='w-72 lg:w-[26rem] pr-2 flex grow flex-col'>
        <p className='font-semibold line-clamp-2 '>
          {phone.brand} {phone.model}, {phone.color}, {phone.memory}GB
        </p>
        <p>Product price: ${phone.price}</p>
        <p className='font-semibold mt-auto py-1 text-xl text-darkblue'>
          ${price.toFixed(2)}
        </p>
      </section>

      <QuantityControl
        quantity={selectedQuantity}
        onIncrement={handleQuantityIncrement}
        onDecrement={handleQuantityDecrement}
      />

      <button
        onClick={() => removeItem(id)}
        className='rounded-full absolute top-3 right-3 cursor-pointer'
      >
        <X size={20} color='var(--color-gray-400)' />
      </button>
    </div>
  );
}
