type ShippingCalculatorProps = {
  subtotal: number;
  shippingCost: number;
};

export default function ShippingCalculator({
  subtotal,
  shippingCost
}: ShippingCalculatorProps) {
  return (
    <section className='flex flex-col text-darkblue'>
      <div className='flex justify-between'>
        <p>Subtotal</p>
        <p className='font-bold'>${subtotal.toFixed(2)}</p>
      </div>

      <div className='flex justify-between'>
        <p>Shipping cost</p>
        <p className='font-bold'>${shippingCost.toFixed(2)}</p>
      </div>

      <hr className='my-3 text-gray-400' />

      <div className='flex justify-between'>
        <p>Total</p>
        <p className='font-bold'>${(subtotal + shippingCost).toFixed(2)}</p>
      </div>
    </section>
  );
}
