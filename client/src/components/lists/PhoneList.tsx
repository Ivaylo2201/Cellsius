import { Phone } from '../../types/Phone';
import PhoneCard from '../cards/PhoneCard';

type PhoneListProps = {
  phones: Phone[];
};

export default function PhoneList({ phones }: PhoneListProps) {
  if (phones.length === 0) {
    return (
      <div className='w-3/5 my-10 lg:w-[65rem] self-center'>
        <p className='font-dmsans text-4xl font-semibold text-darkblue text-center'>
          No phones match your criteria!
        </p>
      </div>
    );
  }

  return (
    <ul className='w-3/5 my-10 lg:my-0 lg:w-[65rem] justify-center lg:justify-normal flex flex-wrap gap-x-5.5 gap-y-5.5'>
      {phones.map((p, i) => (
        <li key={i}>
          <PhoneCard {...p} />
        </li>
      ))}
    </ul>
  );
}
