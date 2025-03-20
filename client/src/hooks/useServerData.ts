import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '../utils/http';

type ServerData = {
  brands: { id: number; name: string }[];
  colors: { id: number; name: string }[];
  shippings: { id: number; type: string; cost: number }[];
};

export default function useServerData() {
  return useSuspenseQuery({
    queryKey: ['data'],
    queryFn: async () => {
      const res = await http.get<ServerData>('/data');
      return res.data;
    },
    staleTime: 24 * 60 * 60 * 1000
  });
}
