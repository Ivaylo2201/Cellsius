import { useState } from 'react';
import { useForm, FormProvider } from 'react-hook-form';
import { Select } from '@mantine/core';
import { CatalogueFilter } from '../../types/CatalogueFilter';
import useServerData from '../../hooks/useServerData';
import convertToSearchParams from '../../utils/convertToSearchParams';
import { useNavigate } from 'react-router';
import PriceRange from '../fields/PriceRange';
import ModelList from '../lists/ModelList';
import SortSelect from '../fields/SortSelect';
import SubmitButton from '../../ui/SubmitButton';
import Centered from '../../layout/Centered';
import Column from '../../layout/Column';
import extractBrand from '../../utils/extractBrand';

export default function FilterForm() {
  const [_, setSelectedBrand] = useState<string | null>(null);

  const methods = useForm<CatalogueFilter>({
    defaultValues: {
      minPrice: 0,
      maxPrice: 2500
    }
  });

  const navigate = useNavigate();
  const { data } = useServerData();

  const onSubmit = (data: CatalogueFilter) => {
    navigate(`/catalogue?${convertToSearchParams(data)}`);
    return;
  };

  return (
    <FormProvider {...methods}>
      <form
        onSubmit={methods.handleSubmit(onSubmit)}
        className='min-w-80 min-h-[44rem] flex flex-col gap-8 border border-gray-200 p-8.5 rounded-2xl shadow font-dmsans'
      >
        <Select
          data={data.brands.map((b) => `${b.name} (${b.count})`)}
          placeholder='Select a value'
          clearable
          description='Brand'
          onChange={(value) => {
            const brand = extractBrand(value);
            setSelectedBrand(brand);
            methods.setValue('brand', brand);
          }}
        />

        <ModelList />

        <PriceRange />

        <Column className='gap-4'>
          <Select
            data={data.colors.map((c) => c.name)}
            placeholder='Select a value'
            onChange={(value) => methods.setValue('color', value)}
            clearable
            description='Color'
          />

          <SortSelect
            data={['Price (Asc)', 'Price (Desc)', 'Discount']}
            description='Sort by'
          />
        </Column>

        <Centered>
          <SubmitButton>Apply</SubmitButton>
        </Centered>
      </form>
    </FormProvider>
  );
}
