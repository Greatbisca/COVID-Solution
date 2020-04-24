using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Utilizadores
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Morada { get; set; }
        public int CC { get; set; }
        public int NIB { get; set; }
        public int Id_Perfil_Utilizador { get; set; }
    }
}
