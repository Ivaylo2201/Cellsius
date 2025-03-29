import Page from '../layout/Page';
import { FormProvider, useForm } from 'react-hook-form';
import { AddPhoneData } from '../types/AddPhoneData';
import AddPhoneForm from '../components/forms/AddPhoneForm';

export default function AddPhonePage() {
  const methods = useForm<AddPhoneData>();

  return (
    <Page>
      <FormProvider {...methods}>
        <AddPhoneForm />
      </FormProvider>
    </Page>
  );
}
