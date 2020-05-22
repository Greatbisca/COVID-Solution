using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.ViewModels
{
    public class Permissoes
    {
        public int Id { get; set; }
        public string Perfil { get; set; }
        public string Modulo { get; set; }
        public bool Ler { get; set; }
        public bool Escrever { get; set; }
        public bool Criar { get; set; }
        public bool Eliminar { get; set; }
    }
}
