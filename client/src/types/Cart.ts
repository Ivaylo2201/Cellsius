import { Item } from "./Item";

export type Cart = {
  items: Item[];
  subtotal: number;
};
