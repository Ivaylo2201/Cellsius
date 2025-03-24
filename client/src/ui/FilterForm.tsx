import { useCallback, useState } from 'react';
import { useForm, useFieldArray } from 'react-hook-form';
import { Checkbox, RangeSlider, Select } from '@mantine/core';
import { CatalogueFilter } from '../types/CatalogueFilter';
import useServerData from '../hooks/useServerData';
import useModels from '../hooks/useModels';
import convertToSearchParams from '../utils/convertToSearchParams';
import { useNavigate } from 'react-router';

export default function FilterForm() {
  const [_, setSelectedBrand] = useState<string | null>(null);

  const { control, setValue, getValues, handleSubmit } =
    useForm<CatalogueFilter>({
      defaultValues: {
        minPrice: 0,
        maxPrice: 2500
      }
    });

  const { fields, append, remove } = useFieldArray({
    control,
    name: 'models'
  });

  const navigate = useNavigate();
  const { data } = useServerData();
  const { data: models } = useModels(getValues('brand'));

  const onSubmit = (data: CatalogueFilter) => {
    navigate(`/catalogue?${convertToSearchParams(data)}`);
    return;
  };

  const handleSortSet = (value: string | null) => {
    const [sortBy, order] = (value as string).split(' ');

    setValue('sortBy', sortBy.toLowerCase());
    setValue(
      'order',
      order === undefined
        ? 'desc'
        : order.slice(1, order.length - 1).toLowerCase()
    );
  };

  const handleModelCheck = useCallback((e: React.ChangeEvent<HTMLInputElement>) => {
      if (e.target.checked) {
        append({ name: e.target.value });
      } else {
        remove(fields.findIndex((f) => f.name === e.target.value));
      }
  }, []);

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className='min-w-80 min-h-[44rem] flex flex-col gap-8 border border-gray-200 p-8.5 rounded-2xl shadow font-dmsans'
    >
      <Select
        data={data.brands.map((b) => b.name)}
        placeholder='Select a brand'
        clearable
        onChange={(value) => {
          setSelectedBrand(value);
          setValue('brand', value);
        }}
      />

      <Checkbox.Group>
        <div className='flex flex-col gap-3 min-h-80'>
          {models?.map((model) => (
            <Checkbox
              key={model.id}
              value={model.name}
              label={model.name}
              onChange={handleModelCheck}
              color='var(--color-blue-400)'
            />
          ))}
        </div>
      </Checkbox.Group>

      <RangeSlider
        min={0}
        max={5000}
        step={50}
        defaultValue={[0, 2500]}
        color='var(--color-blue-400)'
        onChange={(values) => {
          setValue('minPrice', values[0]);
          setValue('maxPrice', values[1]);
        }}
        marks={[
          { value: 0, label: '$0' },
          { value: 2500, label: '$2500' },
          { value: 5000, label: '$5000' }
        ]}
        mb={15}
      />

      <section className='flex flex-col gap-4'>
        <Select
          data={data.colors.map((c) => c.name)}
          placeholder='Select a color'
          onChange={(value) => setValue('color', value)}
        />

        <Select
          data={['Price (Asc)', 'Price (Desc)', 'Discount']}
          placeholder='Sort by'
          onChange={handleSortSet}
        />
      </section>

      <div className='flex justify-center items-center'>
        <button
          className='min-w-32 flex justify-center items-center transition-colors duration-200 cursor-pointer rounded-full px-4 py-2 font-dmsans bg-blue-400 hover:bg-blue-300 text-white'
          type='submit'
        >
          Submit
        </button>
      </div>
    </form>
  );
}
