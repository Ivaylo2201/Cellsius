import { Layout } from "../types/Layout";

export default function Column({ children, className = '' }: Layout) {
  return <div className={`flex flex-col ${className}`}>{children}</div>;
}
