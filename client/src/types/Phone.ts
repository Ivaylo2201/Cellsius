export type Phone = {
  id: number;
  brand: string;
  model: string;
  color: string;
  discountPercentage: number;
  price: {
    initial: number;
    discounted: number;
  };
  memory: number;
  imagePath: string;
};
