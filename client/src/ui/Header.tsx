import { Link } from 'react-router';
import Logo from '../components/miscellaneous/Logo';
import Button from './Button';
import CartButton from './CartButton';
import SearchBox from './SearchBox';

const isAuth = false;

export default function Header() {
  return (
    <header className='bg-white font-dmsans flex flex-col gap-2 pb-2 sm:py-4.5 sm:flex-row sm:justify-around sm:items-center'>
      <section className='sm:w-1/3 flex justify-center items-center mt-2 sm:mt-0'>
        <Logo />
      </section>
      <section className='sm:w-1/3 flex justify-center items-center gap-5 py-2 sm:py-0'>
        <Link to='/catalogue'>Catalogue</Link>
        <SearchBox />
      </section>
      <section className='sm:w-1/3 flex justify-center items-center pt-1 pb-2 sm:pt-0 sm:pb-0'>
        {isAuth ? (
          <div className='flex gap-3'>
            <Button
              to='/register'
              className='bg-blue-400 hover:bg-blue-300 text-white'
            >
              Register
            </Button>
            <Button
              to='/login'
              className='bg-darkblue hover:bg-light-darkblue text-white'
            >
              Login
            </Button>
          </div>
        ) : (
          <div className='flex gap-3'>
            <Button
              to='/phone/add'
              className='bg-blue-400 hover:bg-blue-300 text-white'
            >
              Add Phone
            </Button>
            <CartButton />
          </div>
        )}
      </section>
    </header>
  );
}
