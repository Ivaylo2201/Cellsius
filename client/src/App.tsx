import { BrowserRouter, Route, Routes } from 'react-router';
import PhonesPage from './pages/PhonesPage';
import HomePage from './pages/HomePage';
import CartPage from './pages/CartPage';
import { http } from './utils/http';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import OrdersPage from './pages/OrdersPage';

export default function App() {
  // AUTO LOGIN

  (async () => {
    const res = await http.post<{ token: string }>('/auth/login', {
      email: 'john@example.com',
      password: '12345'
    });

    localStorage.setItem('token', `Bearer ${res.data.token}`);
  })();

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route path='/' element={<HomePage />} />
          <Route path='/catalogue' element={<PhonesPage />} />
          <Route path='/cart' element={<CartPage />} />
          <Route path='/orders' element={<OrdersPage />} />
        </Routes>
      </BrowserRouter>
      <ToastContainer
        autoClose={2000}
        pauseOnHover={false}
        progressClassName={'text-darkblue'}
        toastStyle={{
          backgroundColor: 'var(--color-darkblue)',
          color: 'white',
          fontFamily: 'DM Sans, sans-serif'
        }}
      />
    </>
  );
}
