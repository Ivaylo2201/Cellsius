import Footer from '../ui/Footer';
import Header from '../ui/Header';

type PageProps = {
  className?: string;
} & React.PropsWithChildren;

export default function Page({ children, className = '' }: PageProps) {
  return (
    <div className={`flex flex-col min-h-screen ${className}`}>
      <Header />
      <div className='flex justify-center items-center grow p-10'>
        {children}
      </div>
      <Footer />
    </div>
  );
}
