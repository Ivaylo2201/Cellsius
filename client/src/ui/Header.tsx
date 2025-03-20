import ActionButtons from '../components/miscellaneous/ActionButtons';
import Logo from '../components/miscellaneous/Logo';
import SearchBox from './SearchBox';

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
        <ActionButtons />
      </section>
    </header>
  );
}
