using System.Collections.Generic;
using Paulo.Data.Entities;

namespace Paulo.Core.Services
{
    public interface ILocacaoService : IService<Locacao>
    {
        void RentFilmes(Locacao locacao, List<int> selectedFilmesIds, int userId);
        void UpdateRentFilmes(int locacaoId, List<int> selectedFilmesIds);
    }
}
