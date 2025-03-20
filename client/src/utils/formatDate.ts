export default function formatDate(
  date: string,
  mode?: 'long' | 'short'
) {
  if (mode === 'long') {
    return new Date(date + 'Z')
      .toLocaleString('en-GB', {
        day: '2-digit',
        month: 'long',
        year: 'numeric',
        hour: '2-digit',
        minute: '2-digit',
        hour12: false
      })
      .replace(' at', ',');
  }

  return new Date(date).toLocaleDateString('en-GB', {
    day: '2-digit',
    month: 'long',
    year: 'numeric'
  });
}
