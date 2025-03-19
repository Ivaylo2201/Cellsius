import { Link } from 'react-router';

type ButtonProps = {
  className?: string;
  to?: string;
  onClick?: () => void;
} & React.PropsWithChildren;

export default function Button({
  children,
  to = '',
  className = '',
  onClick
}: ButtonProps) {
  return (
    <Link
      to={to}
      onClick={onClick}
      className={`min-w-32 flex justify-center items-center transition-colors duration-200 cursor-pointer rounded-full px-4 py-2 font-dmsans ${className}`}
    >
      {children}
    </Link>
  );
}
