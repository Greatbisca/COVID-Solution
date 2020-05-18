using System;
using System.Collections.Generic;

namespace DataBase.DataModels
{
    public partial class Hospital
    {
        public Hospital()
        {
            Internamento = new HashSet<Internamento>();
            ProfissionaisDeSaude = new HashSet<ProfissionaisDeSaude>();
        }

        public int IdHospital { get; set; }
        public string Nome { get; set; }
        public string Distrito { get; set; }

        public virtual ICollection<Internamento> Internamento { get; set; }
        public virtual ICollection<ProfissionaisDeSaude> ProfissionaisDeSaude { get; set; }
    }
}
