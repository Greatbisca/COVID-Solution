using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_API.Mappings
{
    public static class PermissoesMapping
    {
        public static DataBase.ViewModels.Permissoes ToViewModel(this DataBase.Models.Permissoes permissao, DataBase.Models.Modulos modulo, DataBase.Models.Perfil_Utilizador perfil)
        {
            return new DataBase.ViewModels.Permissoes()
            {
                Modulo = modulo.Nome,
                Perfil = perfil.Nome,
                Criar = permissao.Criar,
                Eliminar = permissao.Eliminar,
                Escrever = permissao.Escrever,
                Ler = permissao.Ler
            };
        }
    }
}
