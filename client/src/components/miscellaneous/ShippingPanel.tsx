import { Radio, Stack } from '@mantine/core';
import Button from '../../ui/Button';
import { toast } from 'react-toastify';
import { useState } from 'react';

type ShippingProps = {
  subtotal: number;
};

const shippingTypes: Record<'standard' | 'express' | 'next' | 'same', number> =
  {
    standard: 0,
    express: 15.5,
    next: 25,
    same: 40
  };

export default function ShippingPanel({ subtotal }: ShippingProps) {
  const [shippingCost, setShippingCost] = useState<number>(0);

  const placeOrderHandler = () => {
    // TODO: place order logic

    // Send post request to the cart
    // and have it create the order object with the
    // updates items and quantities also send the shipping cost
    // and finally clear the cart
    toast.success('Order placed successfully!');
    return;
  };

  return (
    <section className='max-h-[30rem] flex flex-col gap-8 justify-between border border-gray-200 rounded-2xl p-8'>
      <Radio.Group
        name='shippingType'
        description='Only applicable for workdays.'
        label='Select shipping type'
        onChange={(shippingType) =>
          setShippingCost(
            shippingTypes[shippingType as keyof typeof shippingTypes]
          )
        }
        defaultValue='standard'
        className='flex flex-col'
      >
        <Stack mt={30}>
          <Radio
            value='standard'
            className='text-darkblue'
            label={`Standard (7 Days): ${
              shippingTypes.standard === 0
                ? 'Free'
                : `$${shippingTypes.standard.toFixed(2)}`
            }`}
          />
          <Radio
            value='express'
            className='text-darkblue'
            label={`Express (2-3 Days): +$${shippingTypes.express.toFixed(2)}`}
          />
          <Radio
            value='next'
            className='text-darkblue'
            label={`Next-Day: +$${shippingTypes.next.toFixed(2)}`}
          />
          <Radio
            value='same'
            className='text-darkblue text-xl'
            label={`Same-Day: +$${shippingTypes.same.toFixed(2)}`}
          />
        </Stack>
      </Radio.Group>

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

      <Button
        to='/'
        onClick={placeOrderHandler}
        className='w-32 bg-blue-400 hover:bg-blue-300 text-white'
      >
        Place order
      </Button>
    </section>
  );
}
