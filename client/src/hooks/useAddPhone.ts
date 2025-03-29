import { useMutation, useQueryClient } from '@tanstack/react-query';
import { AddPhoneData } from '../types/AddPhoneData';
import { http } from '../utils/http';

export default function useAddPhone() {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: async (data: AddPhoneData) => {
      const res = await http.post('/phones', data, {
        headers: { 'Content-Type': 'multipart/form-data' }
      });
      return res.data;
    },
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['phones'] });
    }
  });
}
