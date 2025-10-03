using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IBrandRepository : ISingleReadable<Brand, int>, IMultipleReadable<Brand>;