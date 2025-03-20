import { Suspense } from 'react';
import useOrders from '../hooks/useOrders';
import Page from '../layout/Page';
import { Accordion, Loader } from '@mantine/core';
import OrderCard from '../components/cards/OrderCard';

export default function OrdersPage() {
  const { data: orders } = useOrders();

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <Accordion radius='md' className='w-96 md:w-[46rem] lg:w-[62rem]'>
          {orders.map((order, i) => (
            <OrderCard key={i} {...order} />
          ))}
        </Accordion>
      </Suspense>
    </Page>
  );
}
