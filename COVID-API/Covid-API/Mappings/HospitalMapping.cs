using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class HospitalMapping
    {
        public static DataBase.ViewModels.Hospital ToViewModel(this DataBase.Models.Hospital hospital)
        {
            return new DataBase.ViewModels.Hospital()
            {
                Distrito = hospital.Distrito,
                Nome = hospital.Nome
            };
        }

        public static ICollection<DataBase.ViewModels.Hospital> ToViewModel(this ICollection<DataBase.Models.Hospital> hospitais)
        {
            return hospitais.Select(e => e.ToViewModel()).ToList();
        }
    }
}
