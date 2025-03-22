import samsung from '../../assets/samsung.png';
import apple from '../../assets/apple.png';
import xiaomi from '../../assets/xiaomi.png';
import lg from '../../assets/lg.png';
import { Link } from 'react-router';

const data: { brand: string; image: string }[] = [
  { brand: 'Samsung', image: samsung },
  { brand: 'Apple', image: apple },
  { brand: 'Xiaomi', image: xiaomi },
  { brand: 'LG', image: lg }
];

export default function BrandList() {
  return (
    <div className='flex flex-wrap justify-center lg:justify-start gap-6'>
      {data.map(({ brand, image }) => (
        <Link
          to={`/catalogue?brand=${brand.toLowerCase()}`}
          className='flex size-30 flex-col items-center justify-center gap-4 rounded-xl border border-gray-300 bg-white p-3 transition-colors duration-300 hover:border-darkblue'
        >
          <img src={image} alt={brand} className='size-17.5 object-contain' />
        </Link>
      ))}
    </div>
  );
}
