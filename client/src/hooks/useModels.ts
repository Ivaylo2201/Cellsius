import { useQuery } from '@tanstack/react-query';
import { http } from '../utils/http';

export default function useModels(brand: string | null) {
  return useQuery({
    queryKey: ['models', brand],
    queryFn: async () => {
      const res = await http.get<{ id: number; name: string }[]>(
        '/data/models',
        { params: { brand } }
      );
      return res.data;
    },
    staleTime: 24 * 60 * 60 * 1000
  });
}
