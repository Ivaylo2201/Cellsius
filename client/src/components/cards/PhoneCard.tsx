import { ShoppingCart } from 'lucide-react';
import { Phone } from '../../types/Phone';
import { toast } from 'react-toastify';
import useAddToCart from '../../hooks/useAddToCart';
import DiscountLabel from '../miscellaneous/DiscountLabel';

export default function PhoneCard({
  id,
  brand,
  model,
  color,
  discountPercentage,
  price,
  memory,
  imagePath
}: Phone) {
  const { mutateAsync: addToCart } = useAddToCart();

  const handleAddToCart = async (id: number) => {
    await addToCart(id);
    toast.success('Phone added to cart!');
  };

  return (
    <div className='group w-60 flex flex-col p-4 rounded-2xl shadow font-dmsans gap-2 bg-white border border-gray-200 relative'>
      {discountPercentage > 0 && (
        <DiscountLabel discount={discountPercentage} />
      )}

      <img
        className='h-52 object-contain py-5 group-hover:scale-105 transition-transform duration-300'
        src={`${import.meta.env.VITE_IMAGE_ROOT_URL}${imagePath}`}
        alt={`Image of ${brand} ${model}`}
      />

      <h2 className='font-semibold line-clamp-2 h-12'>
        {brand} {model}, {color}, {memory}GB
      </h2>

      <section className='flex items-end justify-between'>
        <div className='flex justify-center items-center gap-2'>
          <p className='text-2xl'>${price.discounted}</p>
          {discountPercentage > 0 && (
            <p className='text-gray-400 text-[1rem] line-through'>
              ${price.initial}
            </p>
          )}
        </div>
        <button

          onClick={() => handleAddToCart(id)}
          className='flex bg-darkblue rounded-lg p-2 gap-2 cursor-pointer hover:bg-light-darkblue transition-colors duration-200'
        >
          <ShoppingCart strokeWidth={1.75} className='text-white' size={20} />
        </button>
      </section>
    </div>
  );
}
