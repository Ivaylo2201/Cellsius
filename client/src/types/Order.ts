import { Phone } from './Phone';

export type Order = {
  id: number;
  total: number;
  items: {
    quantity: number;
    phone: Pick<Phone, 'brand' | 'model' | 'color' | 'imagePath'>;
  }[];
  createdAt: string;
};
