using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase.Models
{
    public class Internamento
    {
        public int Id { get; set; }
        public int Id_Doente { get; set; }
        public int Id_Hospital { get; set; }
        public DateTimeOffset Data_Alta {get; set;}
        public DateTimeOffset Data_Internamento { get; set; }


    }
}
