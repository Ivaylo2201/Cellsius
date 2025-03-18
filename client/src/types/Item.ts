import { Phone } from "./Phone";

export type Item = {
  id: number;
  quantity: number;
  phone: Omit<Phone, 'isLiked'>;
  price: number;
};
