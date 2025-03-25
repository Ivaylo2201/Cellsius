import { Item } from '../../types/Item';
import ItemCard from '../cards/ItemCard';

type ItemListProps = {
  items: Item[];
};

export default function ItemList({ items }: ItemListProps) {
  if (items.length === 0) {
    return (
      <section className='text-center lg:flex lg:justify-center lg:items-center lg:px-20'>
        <h2 className='text-3xl font-semibold text-darkblue'>
          No added items yet.
        </h2>
      </section>
    );
  }

  return (
    <ul className='flex flex-col gap-4'>
      {items.map((item) => (
        <li key={item.id}>
          <ItemCard {...item} />
        </li>
      ))}
    </ul>
  );
}
