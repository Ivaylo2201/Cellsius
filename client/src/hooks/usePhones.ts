import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '../utils/http';
import { Phone } from '../types/Phone';

export default function usePhones(filters: object) {
  return useSuspenseQuery({
    queryKey: ['phones', { filters }],
    queryFn: async () => {
      const res = await http.get<Phone[]>('/phones', { params: filters });
      return res.data;
    },
    staleTime: 60 * 60 * 1000
  });
}
