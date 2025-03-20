import { Suspense } from 'react';
import useOrders from '../hooks/useOrders';
import Page from '../layout/Page';
import { Loader } from '@mantine/core';
import formatDate from '../utils/formatData';

export default function OrdersPage() {
  const { data: orders } = useOrders();

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <div className='flex flex-col gap-8 font-dmsans'>
          {orders.map((order, i) => (
            <div key={i} className='border border-gray-200 rounded-xl p-4'>
              <p className='text-darkblue font-bold text-2xl'>Order #{order.id}</p>
              <p className='italic'>Placed at {formatDate(order.createdAt)}</p>
              <p className='text-xl font-semibol text-darkblue'>Total: ${order.total.toFixed(2)}</p>
            </div>
          ))}
        </div>
      </Suspense>
    </Page>
  );
}
