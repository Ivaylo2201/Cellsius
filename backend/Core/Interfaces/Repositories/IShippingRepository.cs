using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IShippingRepository : ISingleReadable<Shipping, int>, IMultipleReadable<Shipping>;