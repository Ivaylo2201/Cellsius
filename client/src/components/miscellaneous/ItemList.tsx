import { Item } from '../../types/Item';
import ItemCard from '../cards/ItemCard';

type ItemListProps = {
  items: Item[];
};

export default function ItemList({ items }: ItemListProps) {
  if (items.length === 0) {
    return (
      <section>
        <p className='text-xl'>No added items yet.</p>
      </section>
    );
  }

  return (
    <section className='flex flex-col gap-4'>
      {items.map((item) => (
        <ItemCard key={item.id} {...item} />
      ))}
    </section>
  );
}
