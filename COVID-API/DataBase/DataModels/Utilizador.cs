using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class Utilizador
    {
        public Utilizador()
        {
            Doente = new HashSet<Doente>();
            ProfissionaisDeSaude = new HashSet<ProfissionaisDeSaude>();
        }

        public int IdUtilizador { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Sexo { get; set; }
        public string Morada { get; set; }
        public int Cc { get; set; }
        public int Nib { get; set; }
        public int IdPerfilUtilizador { get; set; }
        public string Password { get; set; }

        public virtual PerfilUtilizador IdPerfilUtilizadorNavigation { get; set; }
        public virtual ICollection<Doente> Doente { get; set; }
        public virtual ICollection<ProfissionaisDeSaude> ProfissionaisDeSaude { get; set; }
    }
}
