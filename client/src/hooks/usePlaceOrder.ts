import { useMutation, useQueryClient } from "@tanstack/react-query";
import { http } from "../utils/http";

export default function usePlaceOrder() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (shippingId: number) => {
      const res = await http.post('/order/place', { shippingId });
      return res.data
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['cart'] });
      queryClient.invalidateQueries({ queryKey: ['orders'] });
    }
  })
}