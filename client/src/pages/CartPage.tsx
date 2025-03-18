import { Suspense, useState } from 'react';
import Page from '../layout/Page';
import ItemCard from '../components/cards/ItemCard';
import useCart from '../hooks/useCart';
import { Loader, Radio, Stack } from '@mantine/core';
import Button from '../ui/Button';
import { toast } from 'react-toastify';
import { useNavigate } from 'react-router';

const shippingTypes: Record<'standard' | 'express' | 'next' | 'same', number> =
  {
    standard: 0,
    express: 15,
    next: 25,
    same: 40
  };

export default function CartPage() {
  const [shippingCost, setShippingCost] = useState<number>(0);
  const navigate = useNavigate();

  const { data: cart } = useCart();

  const placeOrderHandler = () => {
    toast.success('Order placed successfully!');
    navigate('/');
    return;
  };

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <div className='flex gap-8'>
          <section className='flex flex-col gap-4'>
            {cart.items.map((item) => (
              <ItemCard key={item.id} {...item} />
            ))}
          </section>

          <section className='flex flex-col gap-8 min-w-[22rem] justify-between border border-gray-200 rounded-2xl p-8'>
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
                  label='Standard (7 Days): Free'
                />
                <Radio
                  value='express'
                  className='text-darkblue'
                  label='Express (2-3 Days): +$15'
                />
                <Radio
                  value='next'
                  className='text-darkblue'
                  label='Next-Day: +$25'
                />
                <Radio
                  value='same'
                  className='text-darkblue text-xl'
                  label='Same-Day: +$40'
                />
              </Stack>
            </Radio.Group>

            <section className='flex flex-col text-darkblue'>
              <div className='flex justify-between'>
                <p>Subtotal</p>
                <p className='font-bold'>${cart.subtotal.toFixed(2)}</p>
              </div>

              <div className='flex justify-between'>
                <p>Shipping cost</p>
                <p className='font-bold'>${shippingCost.toFixed(2)}</p>
              </div>

              <hr className='my-3 text-gray-400' />

              <div className='flex justify-between'>
                <p>Total</p>
                <p className='font-bold'>
                  ${(cart.subtotal + shippingCost).toFixed(2)}
                </p>
              </div>
            </section>

            <Button
              onClick={placeOrderHandler}
              className='w-1/2 bg-blue-400 hover:bg-blue-300 text-white'
            >
              Place order
            </Button>
          </section>
        </div>
      </Suspense>
    </Page>
  );
}
