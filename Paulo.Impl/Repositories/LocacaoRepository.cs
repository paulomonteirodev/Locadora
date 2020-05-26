using Dapper;
using Paulo.Core.Repositories;
using Paulo.Data.Context;
using Paulo.Data.Entities;
using Paulo.Data.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paulo.Impl.Repositories
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(AppDbContext db)
            : base(db)
        {

        }

        public override void Add(Locacao obj)
        {
            obj.DataDaLocacao = DateTime.Now;

            base.Add(obj);
        }

        public override IEnumerable<Locacao> GetAll()
        {
            var cn = db.Database.Connection;
            cn.Open();

            var sql = @"SELECT * FROM Locacao INNER JOIN AspNetUsers ON Locacao.UsuarioId = AspNetUsers.Id WHERE Locacao.Deleted = 0";

            var result = cn.Query<Locacao, ApplicationUser, Locacao>(sql,
                map: (locacao, usuario) =>
                {
                    locacao.Usuario = usuario;
                    return locacao;
                });

            cn.Close();

            return result;
        }

        public void RentFilmes(Locacao locacao, List<int> selectedFilmesIds)
        {
            Add(locacao);
            var filmesToAdd = db.Filme.Where(x => selectedFilmesIds.Contains(x.Id));

            locacao.Filmes.AddRange(filmesToAdd);
            SaveChanges();
        }

        public void UpdateRentFilmes(int locacaoId, List<int> selectedFilmesIds)
        {
            var locacao = GetById(locacaoId);
            var filmesToAdd = db.Filme.Where(x => selectedFilmesIds.Contains(x.Id)).ToList();

            locacao.Filmes.RemoveAll(x => true);
            locacao.Filmes.AddRange(filmesToAdd);

            SaveChanges();
        }
    }
}
