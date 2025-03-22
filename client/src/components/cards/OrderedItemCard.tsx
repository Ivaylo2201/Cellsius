import { Phone } from '../../types/Phone';

type OrderedItemCardProps = {
  id: number;
  quantity: number;
  phone: Pick<Phone, 'brand' | 'model' | 'imagePath'>;
  price: number;
};

export default function OrderedItemCard({
  quantity,
  phone,
  price
}: OrderedItemCardProps) {
  return (
    <div className='flex border border-gray-200 rounded-lg items-center justify-between py-2 pl-4'>
      <section className='flex flex-col'>
        <h2 className='font-bold text-darkblue line-clamp-1'>
          {quantity}x {phone.brand} {phone.model}
        </h2>
        <h3 className='italic text-light-darkblue'>Ordered for ${price}</h3>
      </section>
      <img
        src={`${import.meta.env.VITE_IMAGE_ROOT_URL}${phone.imagePath}`}
        className='size-20 object-contain'
        alt={`Image of ${phone.brand} ${phone.model}`}
      />
    </div>
  );
}
