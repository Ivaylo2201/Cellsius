import { Phone } from './Phone';
import { Shipping } from './Shipping';

export type Order = {
  id: number;
  total: number;
  items: {
    id: number;
    quantity: number;
    phone: Pick<Phone, 'brand' | 'model' | 'imagePath'>;
    price: number;
  }[];
  createdAt: string;
  shipping: Omit<Shipping, 'id'>;
};
