using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class DoenteMapping
    {
        public static DataBase.ViewModels.Doente ToViewModel(this DataBase.Models.Doente doente)
        {
            return new DataBase.ViewModels.Doente()
            {
                Nome = doente.Nome
            };
        }

        public static ICollection<DataBase.ViewModels.Doente> ToViewModel(this ICollection<DataBase.Models.Doente> doentes)
        {
            return doentes.Select(e => e.ToViewModel()).ToList();
        }
    }
}
