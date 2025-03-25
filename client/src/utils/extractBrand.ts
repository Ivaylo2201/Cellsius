export default function extractBrand(value: string | null) {
  return value?.split(' ')[0] ?? null;
}
