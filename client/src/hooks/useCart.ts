import { useSuspenseQuery } from "@tanstack/react-query";
import { http } from "../utils/http";
import { Cart } from "../types/Cart";

export default function useCart() {
  return useSuspenseQuery({
    queryKey: ['cart'],
    queryFn: async () => {
      const res = await http.get<Cart>('/cart');
      return res.data
    }
  })
}