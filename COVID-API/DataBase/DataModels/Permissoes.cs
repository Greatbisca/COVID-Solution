using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class Permissoes
    {
        public int IdPermissao { get; set; }
        public int IdPerfilUtilizador { get; set; }
        public int IdModulo { get; set; }
        public string Ler { get; set; }
        public string Escrever { get; set; }
        public string Criar { get; set; }
        public string Eliminar { get; set; }

        public virtual Modulos IdModuloNavigation { get; set; }
        public virtual PerfilUtilizador IdPerfilUtilizadorNavigation { get; set; }
    }
}
