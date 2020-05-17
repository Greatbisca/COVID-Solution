using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class TesteMapping
    {
        public static DataBase.ViewModels.Teste ToViewModel(this DataBase.Models.Teste teste)
        {
            return new DataBase.ViewModels.Teste()
            {
                Data_Teste = teste.Data_Teste,
                Resultado_Teste = teste.Resultado_Teste,
                Tipo_Teste = teste.Tipo_Teste
            };
        }

        public static ICollection<DataBase.ViewModels.Teste> ToViewModel(this ICollection<DataBase.Models.Teste> testes)
        {
            return testes.Select(e => e.ToViewModel()).ToList();
        }
    }
}
