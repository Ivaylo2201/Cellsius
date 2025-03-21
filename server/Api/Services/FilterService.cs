using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class FilterService(IQueryable<Phone> query)
    {
        private IQueryable<Phone> query = query;

        public IQueryable<Phone> GetQuery()
        {
            return this.query;
        }

        public FilterService ByBrand(string? brandName)
        {
            if (!string.IsNullOrEmpty(brandName))
            {
                this.query = this.query.Where(p => EF.Functions.Like(p.Brand.Name, brandName));
            }

            return this;
        }

        public FilterService ByModel(string? modelName)
        {
            if (!string.IsNullOrEmpty(modelName))
            {
                this.query = this.query.Where(p => EF.Functions.Like(p.Model.Name, modelName));
            }

            return this;
        }

        public FilterService ByColor(string? colorName)
        {
            if (!string.IsNullOrEmpty(colorName))
            {
                this.query = this.query.Where(p => EF.Functions.Like(p.Color.Name, colorName));
            }

            return this;
        }


        public FilterService ByPrice(decimal? price)
        {
            if (price.HasValue && price > 0)
            {
                this.query = this.query.Where(p => p.Price <= price);
            }

            return this;
        }

        public FilterService BySearch(string? search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                this.query = this.query.Where(
                    p => EF.Functions.Like(p.Brand.Name, search) ||
                         EF.Functions.Like(p.Model.Name, search) ||
                         EF.Functions.Like(p.Color.Name, search)
                );
            }

            return this;
        }
    }
}
