using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Type = NetFlixGo.Entities.Type;

namespace NetFlixGo.Repositories
{
    public interface ITypeRepository
    {
        Task<IEnumerable<Type>> GetTypesAsync();
        Task<Type> GetTypeAsync(Guid typeId);
        Task CreateTypeAsync(Type type);
        Task UpdateTypeAsync(Type type);
        Task DeleteTypeAsync(Guid typeId);
    }
}