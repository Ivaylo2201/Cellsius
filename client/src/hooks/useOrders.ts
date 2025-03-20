import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '../utils/http';
import { Order } from '../types/Order';

export default function useOrders() {
  return useSuspenseQuery({
    queryKey: ['orders'],
    queryFn: async () => {
      const res = await http.get<Order[]>('/order');
      return res.data;
    },
    staleTime: 60 * 60 * 1000
  });
}
