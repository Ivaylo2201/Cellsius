using Core.Entities;
using Core.Interfaces.Generic;

namespace Core.Interfaces.Repositories;

public interface IColorRepository : ISingleReadable<Color, int>, IMultipleReadable<Color>;