import { useMutation, useQueryClient } from '@tanstack/react-query';
import { http } from '../utils/http';

export default function useUpdateQuantity(id: number, quantity: number) {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async () => {
      const res = await http.patch<{ message: string }>(`/cart/item/${id}`, {
        quantity
      });
      return res.data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['cart'] });
    }
  });
}
