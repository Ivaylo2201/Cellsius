import { Checkbox } from '@mantine/core';
import { useFieldArray, useFormContext } from 'react-hook-form';
import useModels from '../../hooks/useModels';
import { CatalogueFilter } from '../../types/CatalogueFilter';
import extractBrand from '../../utils/extractBrand';

export default function ModelList() {
  const { control, getValues } = useFormContext<CatalogueFilter>();

  // getValues('brand') is undefined on initial render
  // so we use optional chaining to pass undefined to the hook
  // which will fetch everything instead of the models of the specific brand
  const { data } = useModels(extractBrand(getValues('brand')));

  const { fields, append, remove } = useFieldArray({
    control: control,
    name: 'models'
  });

  const onChange = ({ target }: React.ChangeEvent<HTMLInputElement>) => {
    if (target.checked) {
      append({ name: target.value });
    } else {
      remove(fields.findIndex((f) => f.name === target.value));
    }
  };

  return (
    <Checkbox.Group>
      <ul className='flex flex-col gap-3 min-h-80'>
        {data?.map(({ brand, models }) => (
          <li key={brand} className='flex flex-col gap-2'>
            <h3 className='text-darkblue font-semibold'>{brand}</h3>
            <div className='flex flex-col gap-1.5'>
              {models.map((model) => (
                <Checkbox
                  key={model.id}
                  value={model.name}
                  label={model.name}
                  onChange={onChange}
                  color='var(--color-blue-400)'
                />
              ))}
            </div>
          </li>
        ))}
      </ul>
    </Checkbox.Group>
  );
}
