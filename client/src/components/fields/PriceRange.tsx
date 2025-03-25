import { RangeSlider, RangeSliderValue } from '@mantine/core';
import { useFormContext } from 'react-hook-form';

export default function PriceRange() {
  const { setValue } = useFormContext();

  const onChange = (value: RangeSliderValue) => {
    setValue('minPrice', value[0]);
    setValue('maxPrice', value[1]);
  };

  return (
    <RangeSlider
      min={0}
      max={5000}
      step={50}
      defaultValue={[0, 2500]}
      color='var(--color-blue-400)'
      onChange={onChange}
      marks={[
        { value: 0, label: '$0' },
        { value: 2500, label: '$2500' },
        { value: 5000, label: '$5000' }
      ]}
      mb={15}
    />
  );
}
