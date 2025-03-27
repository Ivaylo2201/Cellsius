import { useMutation, useQueryClient } from '@tanstack/react-query';
import { http } from '../utils/http';

export default function useAddToCart() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (id: number) => {
      const res = await http.post('/carts/add', { phoneId: id });
      return res.data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['carts'] });
    }
  });
}
