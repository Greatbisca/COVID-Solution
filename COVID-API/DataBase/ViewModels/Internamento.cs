using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.ViewModels
{
    public class Internamento
    {
        public int Id { get; set; }
        public string Nome_Doente { get; set; }
        public string Nome_Hospital { get; set; }
        public DateTimeOffset Data_Internamento { get; set; }
        public DateTimeOffset Data_Alta { get; set; }
    }
}
