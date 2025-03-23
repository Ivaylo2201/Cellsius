import { Suspense } from 'react';
import { Loader } from '@mantine/core';
import Page from '../layout/Page';
import useCart from '../hooks/useCart';
import ItemList from '../components/miscellaneous/ItemList';
import ShippingPanel from '../components/miscellaneous/ShippingPanel';

export default function CartPage() {
  const { data: cart } = useCart();

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <main className='flex flex-col lg:flex-row gap-8'>
          <ItemList items={cart.items} />
          <ShippingPanel subtotal={cart.subtotal} />
        </main>
      </Suspense>
    </Page>
  );
}
