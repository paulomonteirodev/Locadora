using Paulo.Core;
using Paulo.Core.Repositories;
using Paulo.Core.Services;
using Paulo.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paulo.Impl.Services
{
    public class LocacaoService : Service<Locacao>, ILocacaoService
    {
        private readonly ILocacaoRepository locacaoRepository;
        private readonly IFilmeRepository filmeRepository;

        public LocacaoService(
            ILocacaoRepository locacaoRepository,
            IFilmeRepository filmeRepository)
            : base(locacaoRepository)
        {
            this.locacaoRepository = locacaoRepository;
            this.filmeRepository = filmeRepository;
        }

        public void RentFilmes(Locacao locacao, List<int> selectedFilmesIds, int userId)
        {
            locacao.UsuarioId = userId;
            locacao.DataDaLocacao = DateTime.Now;
            locacaoRepository.RentFilmes(locacao, selectedFilmesIds);
        }

        public void UpdateRentFilmes(int locacaoId, List<int> selectedFilmesIds)
        {
            locacaoRepository.UpdateRentFilmes(locacaoId, selectedFilmesIds);
        }
    }
}
