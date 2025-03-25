import { Select as MantineSelect } from '@mantine/core';
import { useFormContext } from 'react-hook-form';

type SortSelectProps = {
  data: string[];
  description: string;
};

export default function SortSelect({ data, description }: SortSelectProps) {
  const { setValue } = useFormContext();

  const onChange = (value: string | null) => {
    const [sortBy = '', order] = (value ?? '').split(' ');

    setValue('sortBy', sortBy.toLowerCase());
    setValue('order', order ? order.slice(1, -1).toLowerCase() : 'desc');
  };

  return (
    <MantineSelect
      data={data}
      placeholder='Select a value'
      clearable
      description={description}
      onChange={onChange}
    />
  );
}
