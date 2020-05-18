using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class PerfilUtilizador
    {
        public PerfilUtilizador()
        {
            Permissoes = new HashSet<Permissoes>();
            Utilizador = new HashSet<Utilizador>();
        }

        public int IdPerfilUtilizador { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Permissoes> Permissoes { get; set; }
        public virtual ICollection<Utilizador> Utilizador { get; set; }
    }
}
