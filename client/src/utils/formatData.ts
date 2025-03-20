export default function formatDate(date: string) {
  return new Date(date)
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
