import Logo from '../components/miscellaneous/Logo';
import Button from './Button';
import CartButton from './CartButton';
import SearchBox from './SearchBox';

const isAuth = true;

export default function Header() {
  return (
    <header className='bg-white font-dmsans flex flex-col lg:flex-row justify-around gap-5 lg:gap-0 py-4'>
      <section className='lg:w-1/3 flex justify-center items-center'>
        <Logo />
      </section>
      <section className='lg:w-1/3 flex justify-center items-center'>
        <SearchBox />
      </section>
      <section className='lg:w-1/3 flex justify-center items-center'>
        {isAuth ? (
          <div className='flex gap-4'>
            <Button
              to='/phone/add'
              className='bg-blue-400 flex hover:bg-blue-300 text-white h-auto'
            >
              Add Phone
            </Button>
            <CartButton />
          </div>
        ) : (
          <div className='flex gap-4'>
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
        )}
      </section>
    </header>
  );
}
