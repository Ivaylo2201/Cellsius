import { Suspense } from 'react';
import { Loader } from '@mantine/core';
import useOrders from '../hooks/useOrders';
import Page from '../layout/Page';
import OrderList from '../components/lists/OrderList';

export default function OrdersPage() {
  const { data: orders } = useOrders();

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <OrderList orders={orders} />
      </Suspense>
    </Page>
  );
}
