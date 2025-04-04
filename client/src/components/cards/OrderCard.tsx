import { Accordion } from '@mantine/core';
import { Order } from '../../types/Order';
import addDays from '../../utils/addDays';
import OrderedItemCard from './OrderedItemCard';
import formatDate from '../../utils/formatDate';

export default function OrderCard({
  id,
  total,
  items,
  createdAt,
  shipping
}: Order) {
  return (
    <Accordion.Item value={id.toString()}>
      <Accordion.Control className='rounded-xl transition-colors duration-300'>
        <h2 className='text-darkblue font-bold text-2xl'>Order #{id}</h2>
        <p className='italic text-light-darkblue'>
          {shipping.type} shipping:&nbsp;
          {shipping.cost === 0 ? 'Free' : `$${shipping.cost.toFixed(2)}`}
        </p>
        <p className='italic text text-light-darkblue'>
          Placed on:&nbsp;
          <span className='font-semibold'>{formatDate(createdAt)}</span>,
          Expected on:&nbsp;
          <span className='font-semibold'>
            {formatDate(addDays(createdAt, shipping.days).toString())}
          </span>
        </p>
      </Accordion.Control>
      <Accordion.Panel>
        <section className='pb-5 grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5'>
          {items.map((item) => (
            <OrderedItemCard key={item.id} {...item} />
          ))}
        </section>
        <p className='text-2xl text-darkblue'>
          Total: {items.length} item(s) for ${total.toFixed(2)}
        </p>
      </Accordion.Panel>
    </Accordion.Item>
  );
}
