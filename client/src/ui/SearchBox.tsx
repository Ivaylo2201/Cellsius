import { useState } from 'react';
import { useNavigate } from 'react-router';
import { Search } from 'lucide-react';

export default function SearchBox() {
  const [search, setSearch] = useState<string>('');
  const navigate = useNavigate();

  return (
    <div className='flex'>
      <input
        type='text'
        placeholder='Search...'
        onChange={(e) => setSearch(e.target.value)}
        className='w-80 bg-gray-200 border border-gray-200 text-[#737374] shadow-sx rounded-tl-full rounded-bl-full outline-none py-2 px-4'
      />

      <button
        className='bg-blue-400 hover:bg-blue-300 hover:border-blue-300 transition-colors duration-200 flex justify-center items-center border border-blue-400 rounded-tr-full rounded-br-full pl-3 pr-4 cursor-pointer'
        onClick={() => {
          search === ''
            ? navigate(`/catalogue`)
            : navigate(`/catalogue?search=${search}`);
        }}
      >
        <Search
          strokeWidth={1.75}
          size={20}
          className='text-white transition-colors duration-200'
        />
      </button>
    </div>
  );
}
