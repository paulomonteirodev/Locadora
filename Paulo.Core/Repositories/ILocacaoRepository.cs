using Paulo.Data.Entities;
using System.Collections.Generic;

namespace Paulo.Core.Repositories
{
    public interface ILocacaoRepository : IRepository<Locacao>
    {
        void RentFilmes(Locacao locacao, List<int> selectedFilmesIds);
        void UpdateRentFilmes(int locacaoId, List<int> selectedFilmesIds);
    }
}
