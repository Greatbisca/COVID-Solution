using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class ModulosMapping
    {
        public static DataBase.ViewModels.Modulos ToViewModel(this DataBase.Models.Modulos modulo)
        {
            return new DataBase.ViewModels.Modulos()
            {
                Nome = modulo.Nome
            };
        }

        public static ICollection<DataBase.ViewModels.Modulos> ToViewModel(this ICollection<DataBase.Models.Modulos> modulos)
        {
            return modulos.Select(e => e.ToViewModel()).ToList();
        }
    }
}
