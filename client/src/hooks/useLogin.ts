import { useMutation } from '@tanstack/react-query';
import { http } from '../utils/http';
import { useAuthStore } from '../stores/authStore';
import { LoginData } from '../types/LoginData';

type Response = {
  token: string;
  cart: {
    items: number;
    subtotal: number;
  };
};

export default function useLogin() {
  const { login } = useAuthStore();

  return useMutation({
    mutationFn: async (data: LoginData) => {
      const res = await http.post<Response>('/auth/login', data);
      return res.data;
    },
    onSuccess: (data) => {
      localStorage.setItem('token', `Bearer ${data.token}`);
      login();
    }
  });
}
