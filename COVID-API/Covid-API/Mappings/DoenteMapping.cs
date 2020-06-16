using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class DoenteMapping
    {
        public static DataBase.ViewModels.Doente ToViewModel(this DataBase.Models.Doente doente, DataBase.Models.Utilizadores utilizador)
        {
            return new DataBase.ViewModels.Doente()
            {
                Nome = utilizador.Nome,
                Id = doente.Id
            };
        }
    }
}
