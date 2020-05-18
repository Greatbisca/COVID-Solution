using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class Teste
    {
        public int IdTeste { get; set; }
        public int IdDoente { get; set; }
        public int IdProfissional { get; set; }
        public DateTime DataTeste { get; set; }
        public string TipoTeste { get; set; }
        public string ResultadoTeste { get; set; }

        public virtual Doente IdDoenteNavigation { get; set; }
        public virtual ProfissionaisDeSaude IdProfissionalNavigation { get; set; }
    }
}
