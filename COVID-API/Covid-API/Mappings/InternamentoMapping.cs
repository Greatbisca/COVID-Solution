using DataBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class InternamentoMapping
    {
        public static Internamento ToViewModel(this DataBase.Models.Internamento e, DataBase.Models.Doente doente, DataBase.Models.Hospital hospital)
        {
            return new Internamento()
            {
                Data_Alta = e.Data_Alta,
                Data_Internamento = e.Data_Internamento,
                Nome_Doente = doente.Nome,
                Nome_Hospital = hospital.Nome
            };
        }
    }
}
