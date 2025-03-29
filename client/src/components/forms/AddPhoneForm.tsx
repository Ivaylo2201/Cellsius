import useAddPhone from '../../hooks/useAddPhone';
import { AddPhoneData } from '../../types/AddPhoneData';
import { toast } from 'react-toastify';
import { useFormContext } from 'react-hook-form';
import { useState } from 'react';
import useServerData from '../../hooks/useServerData';
import useModels from '../../hooks/useModels';
import { FileInput, NumberInput, Select } from '@mantine/core';
import SubmitButton from '../../ui/SubmitButton';
import { Image } from 'lucide-react';
import { addPhoneSchema } from '../../schemas/addPhone.schema';
import { useNavigate } from 'react-router';

export default function AddPhoneForm() {
  const [brand, setBrand] = useState<string | null>(null);

  const { data } = useServerData();
  const { data: phones } = useModels(brand);
  const navigate = useNavigate();

  const { mutateAsync } = useAddPhone();
  const { handleSubmit, setValue } = useFormContext<AddPhoneData>();

  const onSubmit = async (data: AddPhoneData) => {
    const result = addPhoneSchema.safeParse(data);

    if (!result.success) {
      toast.error(result.error?.errors[0].message || 'Something went wrong.');
      return;
    }

    try {
      await mutateAsync(data);
      toast.success('Phone added successfully!');
      navigate('/catalogue');
    } catch (error) {
      toast.error('Something went wrong.');
    }
  };

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className='flex flex-col justify-center items-center gap-10 border border-gray-300 rounded-lg p-10'
    >
      <h2 className='font-bold text-3xl text-darkblue'>Add a new phone</h2>
      <div className='grid grid-cols-2 gap-x-6 gap-y-1.5'>
        <Select
          variant='filled'
          data={data.brands.map((b) => b.name)}
          placeholder='Select a brand'
          label='Brand'
          onChange={(brand) => {
            if (brand) {
              setBrand(brand);
              setValue('brand', brand);
            }
          }}
        />
        <Select
          variant='filled'
          data={phones?.flatMap((p) => p.models.map((m) => m.name)) || []}
          disabled={!brand}
          label='Model'
          placeholder={brand ? 'Select a model' : 'Select a brand first'}
          onChange={(model) => {
            if (model) {
              setValue('model', model);
            }
          }}
        />
        <Select
          variant='filled'
          data={data.colors.map((c) => c.name)}
          label='Color'
          clearable
          onChange={(color) => {
            if (color) {
              setValue('color', color);
            }
          }}
          placeholder='Select a color'
        />
        <NumberInput
          variant='filled'
          label='Price'
          placeholder='$250'
          prefix='$'
          onChange={(value) => setValue('price', Number(value))}
        />
        <NumberInput
          variant='filled'
          label='Memory'
          placeholder='256 GB'
          suffix=' GB'
          onChange={(value) => setValue('memory', Number(value))}
        />
        <FileInput
          variant='filled'
          label='Image'
          placeholder='Upload an image'
          rightSectionPointerEvents='none'
          rightSection={<Image color='white' size={18} />}
          styles={{
            input: {
              backgroundColor: 'var(--color-blue-400)'
            },
            placeholder: { color: 'white' }
          }}
          onChange={(value) => {
            if (value) {
              setValue('image', value);
            }
          }}
        />
      </div>

      <SubmitButton>Add</SubmitButton>
    </form>
  );
}
