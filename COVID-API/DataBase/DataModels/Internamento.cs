using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class Internamento
    {
        public int IdInternamento { get; set; }
        public int IdDoente { get; set; }
        public int IdHospital { get; set; }
        public DateTime DataAlta { get; set; }
        public DateTime DataInternamento { get; set; }

        public virtual Doente IdDoenteNavigation { get; set; }
        public virtual Hospital IdHospitalNavigation { get; set; }
    }
}
