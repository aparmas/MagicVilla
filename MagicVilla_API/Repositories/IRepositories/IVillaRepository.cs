using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;

namespace MagicVilla_API.Repositories.IRepositories
{
    public interface IVillaRepository : IRepositories<Villa>
    {
        Task<Villa> UpdateVilla(Villa villa);
    }
}
