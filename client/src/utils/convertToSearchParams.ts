import { CatalogueFilter } from '../types/CatalogueFilter';

export default function convertToSearchParams(obj: CatalogueFilter) {
  const queryParams = new URLSearchParams();

  Object.entries(obj).forEach(([key, value]) => {
    if (Array.isArray(value) && value.length > 0) {
      queryParams.append(key, value.map(({ name }) => name).join(','));
    } else if (typeof value === 'string' || typeof value === 'number') {
      queryParams.append(key, value.toString());
    }
  });

  return queryParams.toString();
}
