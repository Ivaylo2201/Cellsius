import Page from '../layout/Page';
import stand from '../assets/stand.jpg';
import Button from '../ui/Button';
import BrandList from '../components/lists/BrandList';

export default function HomePage() {
  return (
    <Page>
      <section className='flex flex-col items-center gap-10 lg:gap-25 lg:flex-row'>
        <main className='max-w-[62rem] flex flex-col justify-center text-center lg:text-left gap-10'>
          <h3 className='font-dmsans text-5xl lg:text-7xl font-semibold text-darkblue'>
            Find your perfect phone today!
          </h3>
          <h2 className='font-dmsans lg:max-w-3/4 text-2xl text-gray-400'>
            Discover the latest models, exclusive deals, and top-notch customer
            service at unbeatable prices. Whether you're upgrading or buying
            your first phone, we've got something for everyone.
          </h2>
          <div>
            <Button
              to='/catalogue'
              className='inline-flex py-3 bg-blue-400 hover:bg-blue-300 text-white px-8'
            >
              Explore now
            </Button>
          </div>
          <BrandList />
        </main>
        <img
          className='my-10 lg:my-0 h-100 lg:h-150 object-contain'
          src={stand}
          alt='IPhone on a stand'
        />
      </section>
    </Page>
  );
}
