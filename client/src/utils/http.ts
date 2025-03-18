import axios from 'axios';

export const http = axios.create({
  baseURL: 'https://localhost:7168/api'
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
