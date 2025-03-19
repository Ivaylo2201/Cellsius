import { ShoppingCart } from 'lucide-react';
import { Phone } from '../../types/Phone';
import useAddToCart from '../../hooks/useAddToCart';
import { toast } from 'react-toastify';

export default function PhoneCard({
  id,
  brand,
  model,
  color,
  price,
  memory,
  imagePath,
}: Phone) {
  const { mutateAsync: addToCart } = useAddToCart();

  const handleAddToCart = async (id: number) => {
    await addToCart(id);
    toast.success("Phone added to cart!")
  };

  return (
    <div className='group w-60 flex flex-col p-4 rounded-2xl shadow font-dmsans gap-2 bg-white border border-gray-200 relative'>
      <img
        className='h-56 object-cover py-4 group-hover:scale-105 transition-transform duration-300'
        src={`${import.meta.env.VITE_IMAGE_ROOT_URL}${imagePath}`}
        alt={`Image of ${brand} ${model}`}
      />

      <p className='font-semibold line-clamp-2 h-12'>
        {brand} {model}, {color}, {memory}GB
      </p>

      <div className='flex items-center justify-between'>
        <p className='text-2xl'>${price}</p>
        <button onClick={() => handleAddToCart(id)} className='flex bg-darkblue rounded-lg p-2 gap-2 cursor-pointer hover:bg-light-darkblue transition-colors duration-200'>
          <ShoppingCart strokeWidth={1.75} className='text-white' size={20} />
        </button>
      </div>
    </div>
  );
}
