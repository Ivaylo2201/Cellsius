import { Suspense, useState } from 'react';
import { useNavigate } from 'react-router';
import { AxiosError } from 'axios';
import { Loader, Radio, Stack } from '@mantine/core';
import { useDisclosure } from '@mantine/hooks';
import { toast } from 'react-toastify';
import usePlaceOrder from '../../hooks/usePlaceOrder';
import useServerData from '../../hooks/useServerData';
import ShippingCalculator from './ShippingCalculator';
import Button from '../../ui/Button';
import Modal from './Modal';

type ShippingProps = {
  subtotal: number;
};

export default function ShippingPanel({ subtotal }: ShippingProps) {
  const [shippingId, setShippingId] = useState<number>(1);
  const navigate = useNavigate();
  const [opened, { open, close }] = useDisclosure(false);

  const { data } = useServerData();
  const { mutateAsync: placeOrder } = usePlaceOrder();

  const shippingCost = data.shippings.find((s) => s.id === shippingId)?.cost || 0;

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
    <aside className='max-h-[31rem] flex flex-col gap-8 justify-between border border-gray-200 rounded-2xl p-8'>
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
        onClick={open}
        className='w-32 bg-blue-400 hover:bg-blue-300 text-white'
      >
        Place order
      </Button>

      <Modal
        opened={opened}
        onClose={close}
        header={
          <p className='font-dmsans font-semibold text-darkblue'>
            Are you sure you want to place this order?
          </p>
        }
        body={
          <Button
            onClick={placeOrderHandler}
            className='w-32 bg-blue-400 hover:bg-blue-300 text-white'
          >
            Place order
          </Button>
        }
      />
    </aside>
  );
}
