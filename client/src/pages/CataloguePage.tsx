import { Suspense } from 'react';
import { Loader } from '@mantine/core';
import { useSearchParams } from 'react-router';
import Page from '../layout/Page';
import usePhones from '../hooks/usePhones';
import PhoneList from '../components/miscellaneous/PhoneList';
import FilterForm from '../ui/FilterForm';

export default function CataloguePage() {
  const [search] = useSearchParams();
  const { data: phones } = usePhones(Object.fromEntries(search.entries()));

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <main className='min-h-[47rem] flex flex-col lg:flex-row items-center lg:items-start gap-7'>
          <FilterForm />
          <PhoneList phones={phones} />
        </main>
      </Suspense>
    </Page>
  );
}
