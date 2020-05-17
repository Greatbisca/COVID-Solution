using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Teste
    {
        public int Id { get; set; }
        public int Id_Doente { get; set; }
        public int Id_Profissional { get; set; }
        public DateTimeOffset Data_Teste { get; set; }
        public string Tipo_Teste { get; set; }

        public string Resultado_Teste { get; set; }
    }
}
