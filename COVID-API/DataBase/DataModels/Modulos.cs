using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class Modulos
    {
        public Modulos()
        {
            Permissoes = new HashSet<Permissoes>();
        }

        public int IdModulos { get; set; }
        public string Nome { get; set; }
        public string Endpoint { get; set; }

        public virtual ICollection<Permissoes> Permissoes { get; set; }
    }
}
