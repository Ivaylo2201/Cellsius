import { BrowserRouter, Route, Routes } from 'react-router';
import HomePage from './pages/HomePage';
import PhonesPage from './pages/CataloguePage';
import CartPage from './pages/CartPage';
import OrdersPage from './pages/OrdersPage';
import RegisterPage from './pages/RegisterPage';
import LoginPage from './pages/LoginPage';
import Guard from './components/miscellaneous/Guard';
import AddPhonePage from './pages/AddPhonePage';

export default function Router() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path='/' element={<HomePage />} />
        <Route path='/catalogue' element={<PhonesPage />} />
        <Route
          path='/cart'
          element={
            <Guard>
              <CartPage />
            </Guard>
          }
        />
        <Route
          path='/orders'
          element={
            <Guard>
              <OrdersPage />
            </Guard>
          }
        />
        <Route
          path='/add-phone'
          element={
            <Guard>
              <AddPhonePage />
            </Guard>
          }
        />
        <Route path='/auth'>
          <Route path='register' element={<RegisterPage />} />
          <Route path='login' element={<LoginPage />} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
}
