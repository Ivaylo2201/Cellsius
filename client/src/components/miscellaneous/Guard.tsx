import { Navigate } from 'react-router';
import { useAuthStore } from '../../stores/authStore';

export default function Guard({ children }: React.PropsWithChildren) {
  const { isAuthenticated } = useAuthStore();

  return isAuthenticated ? children : <Navigate to='/auth/login' />;
}
