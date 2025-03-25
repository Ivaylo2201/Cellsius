import { Layout } from '../types/Layout';

export default function Centered({ children, className = '' }: Layout) {
  return (
    <div className={`flex justify-center items-center ${className}`}>
      {children}
    </div>
  );
}
