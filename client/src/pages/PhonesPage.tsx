import { Suspense } from 'react';
import { Loader } from '@mantine/core';
import { useSearchParams } from 'react-router';
import Page from '../layout/Page';
import usePhones from '../hooks/usePhones';
import PhoneList from '../components/miscellaneous/PhoneList';

export default function PhonesPage() {
  const [search] = useSearchParams();
  const { data: phones } = usePhones(Object.fromEntries(search.entries()));

  return (
    <Page>
      <Suspense fallback={<Loader color={'var(--color-blue-400)'} />}>
        <PhoneList phones={phones} />
      </Suspense>
    </Page>
  );
}
