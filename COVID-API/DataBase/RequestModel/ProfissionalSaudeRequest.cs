using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.RequestModel
{
    public class ProfissionalSaudeRequest
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string Morada { get; set; }
        public int CC { get; set; }
        public int NIB { get; set; }
        public string Profissao { get; set; }
        public int Id_Hospital { get; set; }

    }
}
