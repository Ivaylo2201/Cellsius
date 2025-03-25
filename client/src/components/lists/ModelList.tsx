import { Checkbox } from '@mantine/core';
import { ChangeEvent } from 'react';

type ModelListProps = {
  models?: { id: number; name: string }[];
  onChange: (e: ChangeEvent<HTMLInputElement>) => void;
};

export default function ModelList({ models, onChange }: ModelListProps) {
  return (
    <Checkbox.Group>
      <div className='flex flex-col gap-3 min-h-80'>
        {models?.map((model) => (
          <Checkbox
            key={model.id}
            value={model.name}
            label={model.name}
            onChange={onChange}
            color='var(--color-blue-400)'
          />
        ))}
      </div>
    </Checkbox.Group>
  );
}
