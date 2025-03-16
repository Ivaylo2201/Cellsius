import { ShoppingCart, Heart } from 'lucide-react';
import { Phone } from '../../types/Phone';

export default function PhoneCard({
  id,
  brand,
  model,
  color,
  price,
  memory,
  imagePath,
  isLiked
}: Phone) {
  return (
    <div className='group w-60 flex flex-col p-4 rounded-2xl shadow font-dmsans gap-2 bg-white border border-gray-200 relative'>
      <img
        className='h-56 object-cover py-4'
        src={`${import.meta.env.VITE_IMAGE_ROOT_URL}${imagePath}`}
        alt={`Image of ${brand} ${model}`}
      />

      <p className='font-semibold line-clamp-2 h-12'>
        {brand} {model}, {color}, {memory}GB
      </p>

      <div className='flex items-center justify-between'>
        <p className='text-2xl'>${price}</p>
        <button className='flex bg-darkblue rounded-lg p-2 gap-2 cursor-pointer hover:bg-light-darkblue transition-colors duration-200'>
          <ShoppingCart strokeWidth={1.75} className='text-white' size={20} />
        </button>
      </div>

      <div className='inline-flex flex-col absolute top-2.5 left-2.5 gap-1 opacity-0 group-hover:opacity-100 transition-opacity duration-200'>
        <button className='p-2 rounded-full bg-gray-100 border border-gray-200 cursor-pointer'>
          <Heart
            size={20}
            strokeWidth={1.5}
            color={isLiked ? '#eb1345' : '#262626'}
            fill={isLiked ? '#eb1345' : 'none'}
          />
        </button>
      </div>
    </div>
  );
}
