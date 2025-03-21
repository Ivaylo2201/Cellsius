import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { createTheme, MantineProvider } from '@mantine/core';
import { ToastContainer } from 'react-toastify';
import './index.css';
import '@mantine/core/styles.css';
import 'react-toastify/dist/ReactToastify.css';
import Router from './Router';

const queryClient = new QueryClient();

const theme = createTheme({
  fontFamily: `'DM Sans', sans-serif`,
  cursorType: 'pointer'
});

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <MantineProvider theme={theme}>
      <QueryClientProvider client={queryClient}>
        <Router />
        <ToastContainer
          autoClose={1500}
          pauseOnHover={false}
          toastStyle={{
            backgroundColor: 'var(--color-darkblue)',
            color: 'white',
            fontFamily: 'DM Sans, sans-serif'
          }}
        />
      </QueryClientProvider>
    </MantineProvider>
  </StrictMode>
);
