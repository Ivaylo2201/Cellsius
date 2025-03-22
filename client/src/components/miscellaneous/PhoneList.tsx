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
    <ul className='w-4/5 flex flex-wrap justify-center items-center gap-5'>
      {phones.map((p, i) => (
        <li key={i}>
          <PhoneCard {...p} />
        </li>
      ))}
    </ul>
  );
}
