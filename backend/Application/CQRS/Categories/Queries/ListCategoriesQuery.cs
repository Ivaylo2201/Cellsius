using Core.Abstractions;
using Core.Entities;
using MediatR;

namespace Application.CQRS.Categories.Queries;

public record ListCategoriesQuery : IRequest<Result<List<Category>>>;