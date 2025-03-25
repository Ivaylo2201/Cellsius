type SubmitButtonProps = React.PropsWithChildren;

export default function SubmitButton({ children }: SubmitButtonProps) {
  return (
    <button
      className='min-w-32 flex justify-center items-center transition-colors duration-200 cursor-pointer rounded-full px-4 py-2 font-dmsans bg-blue-400 hover:bg-blue-300 text-white'
      type='submit'
    >
      {children}
    </button>
  );
}
