using Paulo.Data.Entities;
using System.Collections.Generic;

namespace Paulo.Core.Services
{
    public interface IFilmeService : IService<Filme>
    {
        List<Filme> GetAllToSelect();
    }
}
