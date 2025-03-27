import { useMutation } from '@tanstack/react-query';
import { RegisterData } from '../types/Register';
import { http } from '../utils/http';
import { useAuthStore } from '../stores/authStore';

export default function useRegister() {
  const { login } = useAuthStore();

  return useMutation({
    mutationFn: async (data: RegisterData) => {
      const res = await http.post('/auth/register', data);
      return res.data;
    },
    onSuccess: (data) => {
      localStorage.setItem('token', `Bearer ${data.token}`);
      login();
    }
  });
}
