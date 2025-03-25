import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '../utils/http';
import { Shipping } from '../types/Shipping';

type ServerData = {
  brands: { id: number; name: string, count: number }[];
  colors: { id: number; name: string }[];
  shippings: Shipping[];
};

export default function useServerData() {
  return useSuspenseQuery({
    queryKey: ['data'],
    queryFn: async () => {
      const res = await http.get<ServerData>('/data');
      return res.data;
    },
    staleTime: 60 * 60 * 1000
  });
}
