import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';
import App from './App';
import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { createTheme, MantineProvider } from '@mantine/core';
import '@mantine/core/styles.css';

const queryClient = new QueryClient();

const theme = createTheme({
  fontFamily: `'DM Sans', sans-serif`,
  cursorType: 'pointer',
});

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <MantineProvider theme={theme}>
      <QueryClientProvider client={queryClient}>
        <App />
      </QueryClientProvider>
    </MantineProvider>
  </StrictMode>
);
