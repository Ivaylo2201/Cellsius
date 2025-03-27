import { LogOut } from 'lucide-react';
import { Link } from 'react-router';
import { useAuthStore } from '../stores/authStore';

type LogoutButtonProps = {};

export default function LogoutButton({}: LogoutButtonProps) {
  const { logout } = useAuthStore();

  return (
    <Link
      to='/'
      onClick={logout}
      className='size-10 flex bg-darkblue hover:bg-light-darkblue duration-200 transition-colors justify-center items-center rounded-full p-2 cursor-pointer relative font-dmsans'
    >
      <LogOut color='white' strokeWidth={2} size={20} />
    </Link>
  );
}
