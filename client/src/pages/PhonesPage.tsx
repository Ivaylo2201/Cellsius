import { Suspense } from 'react';
import { Loader } from '@mantine/core';
import { useSearchParams } from 'react-router';
import Page from '../layout/Page';
import PhoneCard from '../components/cards/PhoneCard';
import usePhones from '../hooks/usePhones';

export default function PhonesPage() {
  const [search] = useSearchParams();
  const { data: phones } = usePhones(Object.fromEntries(search.entries()));

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <div className='w-4/5 flex flex-wrap justify-center items-center gap-5'>
          {phones.length === 0 ? (
            <p className='font-dmsans text-4xl font-semibold text-darkblue'>
              No phones match your criteria!
            </p>
          ) : (
            phones.map((p, i) => <PhoneCard key={i} {...p} />)
          )}
        </div>
      </Suspense>
    </Page>
  );
}
