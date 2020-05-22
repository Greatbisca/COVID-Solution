using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class Doente
    {
        public Doente()
        {
            Internamento = new HashSet<Internamento>();
            Teste = new HashSet<Teste>();
        }

        public int IdDoente { get; set; }
        public int IdUtilizador { get; set; }
        public string Regiao { get; set; }

        public virtual Utilizador IdUtilizadorNavigation { get; set; }
        public virtual ICollection<Internamento> Internamento { get; set; }
        public virtual ICollection<Teste> Teste { get; set; }
    }
}
