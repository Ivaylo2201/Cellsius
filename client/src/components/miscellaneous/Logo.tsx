import { Link } from 'react-router';

export default function Logo() {
  return (
    <Link to='/' className='uppercase text-4xl font-bold'>
      <span className='text-blue-400'>cell</span>
      <span className='text-darkblue'>sius°</span>
    </Link>
  );
}
