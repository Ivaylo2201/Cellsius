import { RangeSlider, RangeSliderValue } from '@mantine/core';

type RangeProps = {
  onChange: (values: RangeSliderValue) => void;
};

export default function Range({ onChange }: RangeProps) {
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
