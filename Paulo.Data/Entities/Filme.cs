using System.ComponentModel.DataAnnotations.Schema;

namespace Paulo.Data.Entities
{
    public class Filme : BaseEntity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }

        [ForeignKey(nameof(Genero))]
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }

        [ForeignKey(nameof(Locacao))]
        public int? LocacaoId { get; set; }
        public virtual Locacao Locacao { get; set; }
    }
}
