using Application.CQRS.Categories.Queries;
using Core.Abstractions;
using Core.Entities;
using Core.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Categories.Handlers;

public class ListCategoriesQueryHandler(ICategoryRepository categoryRepository) : 
    IRequestHandler<ListCategoriesQuery, Result<List<Category>>>
{
    public async Task<Result<List<Category>>> Handle(ListCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categoriesResult = await categoryRepository.GetAllAsync();
        return Result.Success(categoriesResult.Value);
    }
}