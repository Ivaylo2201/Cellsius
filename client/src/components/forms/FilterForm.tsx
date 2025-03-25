import { useCallback, useState } from 'react';
import { useForm, useFieldArray } from 'react-hook-form';
import { Select } from '@mantine/core';
import { CatalogueFilter } from '../../types/CatalogueFilter';
import useServerData from '../../hooks/useServerData';
import useModels from '../../hooks/useModels';
import convertToSearchParams from '../../utils/convertToSearchParams';
import { useNavigate } from 'react-router';
import ModelsList from '../lists/ModelList';
import Range from '../fields/Range';
import { CheckEvent } from '../../utils/checkEvent';

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

  const handleSortSet = useCallback((value: string | null) => {
    const [sortBy = '', order] = (value ?? '').split(' ');

    setValue('sortBy', sortBy.toLowerCase());
    setValue('order', order ? order.slice(1, -1).toLowerCase() : 'desc');
  }, []);

  const handleModelCheck = useCallback(({ target }: CheckEvent) => {
    target.checked
      ? append({ name: target.value })
      : remove(fields.findIndex((f) => f.name === target.value));
  }, []);

  return (
    <form
      onSubmit={handleSubmit(onSubmit)}
      className='min-w-80 min-h-[44rem] flex flex-col gap-8 border border-gray-200 p-8.5 rounded-2xl shadow font-dmsans'
    >
      <Select
        data={data.brands.map((b) => b.name)}
        placeholder='Select a value'
        clearable
        description='Brand'
        onChange={(value) => {
          setSelectedBrand(value);
          setValue('brand', value);
        }}
      />

      <ModelsList models={models} onChange={handleModelCheck} />

      <Range
        onChange={(values) => {
          setValue('minPrice', values[0]);
          setValue('maxPrice', values[1]);
        }}
      />

      <section className='flex flex-col gap-4'>
        <Select
          data={data.colors.map((c) => c.name)}
          placeholder='Select a value'
          onChange={(value) => setValue('color', value)}
          clearable
          description='Color'
        />

        <Select
          data={['Price (Asc)', 'Price (Desc)', 'Discount']}
          placeholder='Select a value'
          onChange={handleSortSet}
          clearable
          description='Sort by'
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
