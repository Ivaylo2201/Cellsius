import axios from 'axios';
import { toast } from 'react-toastify';

export const http = axios.create({
  baseURL: `${import.meta.env.VITE_API_URL}`
});

http.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers['Authorization'] = token;
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

http.interceptors.response.use(
  (response) => {
    return response;
  },
  (error) => {
    if (error.response && error.response.status === 401) {
      toast.error('Your session has expired, please login again!');
      localStorage.removeItem('token');
      window.location.href = '/auth/login';
    }

    Promise.reject(error);
  }
);
