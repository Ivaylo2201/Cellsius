import { useQuery } from '@tanstack/react-query';
import { http } from '../utils/http';
import { Model } from '../types/Model';

type Response = {
  brand: string;
  models: Model[];
}[];

export default function useModels(brand: string | null) {
  return useQuery({
    queryKey: ['models', brand],
    queryFn: async () => {
      const res = await http.get<{ brand: string; models: Model[] }[]>(
        '/data/models',
        {
          params: { brand }
        }
      );
      return res.data;
    },
    staleTime: 24 * 60 * 60 * 1000
  });
}
