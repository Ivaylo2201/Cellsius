import { useMutation, useQueryClient } from '@tanstack/react-query';
import { http } from '../utils/http';

export default function useRemoveItem() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (id: number) => {
      await http.delete(`/cart/remove/${id}`);
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['cart'] });
    }
  });
}
