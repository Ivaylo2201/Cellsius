import { BrowserRouter, Route, Routes } from 'react-router';
import HomePage from './pages/HomePage';
import PhonesPage from './pages/CataloguePage';
import CartPage from './pages/CartPage';
import OrdersPage from './pages/OrdersPage';

import { http } from './utils/http';
import RegisterPage from './pages/RegisterPage';

export default function Router() {
  (async () => {
    const res = await http.post<{ token: string }>('/auth/login', {
      email: 'ivailo_g03@abv.bg',
      password: '12345'
    });

    localStorage.setItem('token', `Bearer ${res.data.token}`);
  })();

  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<HomePage />} />
        <Route path='/catalogue' element={<PhonesPage />} />
        <Route path='/cart' element={<CartPage />} />
        <Route path='/orders' element={<OrdersPage />} />
        <Route path='/auth'>
          <Route path='register' element={<RegisterPage />} />
          <Route path='login' element={<></>} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
