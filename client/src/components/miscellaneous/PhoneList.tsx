import { Phone } from '../../types/Phone';
import PhoneCard from '../cards/PhoneCard';

type PhoneListProps = {
  phones: Phone[];
};

export default function PhoneList({ phones }: PhoneListProps) {
  if (phones.length === 0) {
    return (
      <p className='font-dmsans text-4xl font-semibold text-darkblue'>
        No phones match your criteria!
      </p>
    );
  }

  return (
    <ul className='w-3/5 lg:w-[65rem] flex flex-wrap gap-x-5.5 gap-y-5.5'>
      {phones.map((p, i) => (
        <li key={i}>
          <PhoneCard {...p} />
        </li>
      ))}
    </ul>
  );
}
