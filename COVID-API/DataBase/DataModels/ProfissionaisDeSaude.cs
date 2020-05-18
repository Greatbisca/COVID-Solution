using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class ProfissionaisDeSaude
    {
        public ProfissionaisDeSaude()
        {
            Teste = new HashSet<Teste>();
        }

        public int IdProfissional { get; set; }
        public int IdUtilizador { get; set; }
        public string Profissao { get; set; }
        public int? IdHospital { get; set; }
        public string Nome { get; set; }

        public virtual Hospital IdHospitalNavigation { get; set; }
        public virtual Utilizador IdUtilizadorNavigation { get; set; }
        public virtual ICollection<Teste> Teste { get; set; }
    }
}
