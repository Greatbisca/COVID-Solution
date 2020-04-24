using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Permissoes
    {
        public int Id { get; set; }
        public int Id_Perfil_Utilizador { get; set; }
        public int Id_Modulo { get; set; }
        public bool Ler { get; set; }
        public bool Escrever { get; set; }
        public bool Criar { get; set; }
        public bool Eliminar { get; set; }
    }
}
