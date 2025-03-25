import { Link } from 'react-router';

export default function Footer() {
  return (
    <footer className='lg:mt-5 flex flex-col lg:flex-row lg:justify-around bg-[#1e282b]'>
      <section className='text-white p-5 flex justify-center items-center gap-8'>
        <Link to='/'>Home</Link>
        <Link to='/catalogue'>Catalogue</Link>
        <Link to='/login'>Login</Link>
      </section>
      <section className='text-white p-5 flex justify-center items-center gap-8'>
        <p>© {new Date().getFullYear()} Cellsius. All rights reserved.</p>
      </section>
      <section className='text-white p-5 flex justify-center items-center gap-8'>
        <p>Working times: Mon-Fri 09:00-18:00</p>
      </section>
    </footer>
  );
}
