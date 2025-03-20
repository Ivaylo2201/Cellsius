import { Loader, Radio, Stack } from '@mantine/core';
import Button from '../../ui/Button';
import { toast } from 'react-toastify';
import { Suspense, useState } from 'react';
import usePlaceOrder from '../../hooks/usePlaceOrder';
import { AxiosError } from 'axios';
import { useNavigate } from 'react-router';
import useServerData from '../../hooks/useServerData';
import ShippingCalculator from './ShippingCalculator';

type ShippingProps = {
  subtotal: number;
};

export default function ShippingPanel({ subtotal }: ShippingProps) {
  const { data } = useServerData();
  const [shippingId, setShippingId] = useState<number>(1);

  const shippingCost =
    data.shippings.find((shipping) => {
      return shipping.id === shippingId;
    })?.cost || 0;

  const { mutateAsync: placeOrder } = usePlaceOrder();
  const navigate = useNavigate();

  const placeOrderHandler = async () => {
    try {
      await placeOrder(shippingId);
      toast.success('Order placed successfully!');
      navigate('/orders');
    } catch (error) {
      if (error instanceof AxiosError) {
        toast.error(error.response?.data.message);
      }
    }
  };

  return (
    <section className='max-h-[31rem] flex flex-col gap-8 justify-between border border-gray-200 rounded-2xl p-8'>
      <Radio.Group
        name='shippingType'
        description='Only applicable for workdays.'
        label='Select shipping type'
        onChange={(shippingId) => setShippingId(Number(shippingId))}
        defaultValue={shippingId.toString()}
        className='flex flex-col'
      >
        <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
          <Stack mt={30}>
            {data.shippings.map((shipping, i) => (
              <Radio
                key={i}
                value={shipping.id.toString()}
                className='text-darkblue'
                label={`${shipping.type}: $${shipping.cost.toFixed(2)}`}
              />
            ))}
          </Stack>
        </Suspense>
      </Radio.Group>

      <ShippingCalculator subtotal={subtotal} shippingCost={shippingCost} />

      <Button
        onClick={placeOrderHandler}
        className='w-32 bg-blue-400 hover:bg-blue-300 text-white'
      >
        Place order
      </Button>
    </section>
  );
}
