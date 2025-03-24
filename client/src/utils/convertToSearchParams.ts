import { CatalogueFilter } from '../types/CatalogueFilter';

export default function convertToSearchParams(obj: CatalogueFilter) {
  const queryParams = new URLSearchParams();

  Object.entries(obj).forEach(([key, value]) => {
    if (value) {
      switch (typeof value) {
        case 'string':
        case 'number':
          queryParams.append(key, value.toString());
          break;
        case 'object':
          if (Array.isArray(value) && value.length > 0) {
            queryParams.append(key, value.map(({ name }) => name).join(','));
          } else {
            Object.entries(value).forEach(([k, v]) =>
              queryParams.append(k, v.toString())
            );
          }
      }
    }
  });

  return queryParams.toString();
}
