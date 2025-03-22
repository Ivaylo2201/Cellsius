import { Accordion } from '@mantine/core';
import { Order } from '../../types/Order';
import OrderCard from '../cards/OrderCard';

type OrderListProps = {
  orders: Order[];
};

export default function OrderList({ orders }: OrderListProps) {
  if (orders.length === 0) {
    return <p>No orders</p>;
  }

  return (
    <Accordion radius='md' className='w-96 md:w-[46rem] lg:w-[62rem]'>
      {orders.map((order, i) => (
        <OrderCard key={i} {...order} />
      ))}
    </Accordion>
  );
}
