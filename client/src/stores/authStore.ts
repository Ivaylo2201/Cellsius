import { create } from 'zustand';

type AuthStore = {
  isAuthenticated: boolean;
  login: () => void;
  logout: () => void;
};

export const useAuthStore = create<AuthStore>((set) => ({
  isAuthenticated: !!localStorage.getItem('token'),
  login: () => set({ isAuthenticated: true }),
  logout: () => {
    set({ isAuthenticated: false });
    localStorage.removeItem('token');
  }
}));
