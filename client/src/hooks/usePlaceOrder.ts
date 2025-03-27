import { useMutation, useQueryClient } from "@tanstack/react-query";
import { http } from "../utils/http";

export default function usePlaceOrder() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (shippingId: number) => {
      const res = await http.post('/orders/place', { shippingId });
      return res.data
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['carts'] });
      queryClient.invalidateQueries({ queryKey: ['orders'] });
    }
  })
}