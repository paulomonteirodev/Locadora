using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Paulo.Data.Entities
{
    public class Locacao : BaseEntity
    {
        public DateTime DataDaLocacao { get; set; }

        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public virtual List<Filme> Filmes { get; set; }

    }
}
