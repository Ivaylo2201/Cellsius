import { useSuspenseQuery } from '@tanstack/react-query';
import { http } from '../utils/http';
import { Phone } from '../types/Phone';

export default function usePhones(filters: object) {
  return useSuspenseQuery({
    queryKey: ['phones', { filters }],
    queryFn: async () => {
      console.log('fetching');
      const res = await http.get<Phone[]>('/phone/public', { params: filters });
      return res.data;
    },
  });
}
