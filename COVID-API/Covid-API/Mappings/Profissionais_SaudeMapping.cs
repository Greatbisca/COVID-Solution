using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class Profissionais_SaudeMapping
    {
        public static DataBase.ViewModels.Profissionais_Saude ToViewModel(this DataBase.Models.Profissionais_Saude profissional, DataBase.Models.Utilizadores utilizador)
        {
            return new DataBase.ViewModels.Profissionais_Saude()
            {
                Nome = utilizador.Nome,
                Profissao = profissional.Profissao
            };
        }
    }
}
