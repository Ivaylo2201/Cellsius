import { BrowserRouter, Route, Routes } from 'react-router';
import PhonesPage from './pages/PhonesPage';
import HomePage from './pages/HomePage';
import CartPage from './pages/CartPage';
import { http } from './utils/http';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

export default function App() {
  // AUTO LOGIN

  (async () => {
    const res = await http.post<{ token: string }>('/auth/login', {
      email: 'ivo@ivo.bg',
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
        </Routes>
      </BrowserRouter>
      <ToastContainer autoClose={3000} pauseOnHover={false} theme='dark' />
    </>
  );
}
