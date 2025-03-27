import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '../utils/http';
import { Cart } from '../types/Cart';

export default function useCart() {
  return useSuspenseQuery({
    queryKey: ['carts'],
    queryFn: async () => {
      const res = await http.get<Cart>('/carts');
      return res.data;
    },
    staleTime: 60 * 60 * 1000
  });
}
