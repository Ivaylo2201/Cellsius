using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IModelRepository : ISingleReadable<Model, int>, IMultipleReadable<Model>;