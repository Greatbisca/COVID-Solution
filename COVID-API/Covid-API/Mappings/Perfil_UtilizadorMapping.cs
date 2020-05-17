using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class Perfil_UtilizadorMapping
    {
        public static DataBase.ViewModels.Perfil_Utilizador ToViewModel(this DataBase.Models.Perfil_Utilizador perfil_utilizador)
        {
            return new DataBase.ViewModels.Perfil_Utilizador()
            {
                Nome = perfil_utilizador.Nome
            };
        }

        public static ICollection<DataBase.ViewModels.Perfil_Utilizador> ToViewModel(this ICollection<DataBase.Models.Perfil_Utilizador> perfis_utilizador)
        {
            return perfis_utilizador.Select(e => e.ToViewModel()).ToList();
        }
    }
}
