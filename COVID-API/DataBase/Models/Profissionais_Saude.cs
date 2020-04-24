using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Profissionais_Saude
    {
        public int Id { get; set; }
        public int Id_Utilizador { get; set; }
        public string Profissao { get; set; }
        public int Id_Hospital { get; set; }
    }
}
