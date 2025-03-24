type DiscountLabelProps = {
  discount: number;
};

export default function DiscountLabel({ discount }: DiscountLabelProps) {
  return (
    <span className='absolute z-50 top-3 left-3 bg-blue-400 text-1xl text-white px-2 py-1 rounded-md'>
      -{discount}%
    </span>
  );
}
