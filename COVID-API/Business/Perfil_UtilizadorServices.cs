using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class Perfil_UtilizadorServices : IPerfil_UtilizadoresServices
    {
        public Task<DataBase.ViewModels.Perfil_Utilizador> CreateAsync(DataBase.Models.Perfil_Utilizador perfil_utilizador, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Perfil_Utilizador>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Perfil_Utilizador> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Perfil_Utilizador> UpdateAsync(int id, DataBase.Models.Perfil_Utilizador perfil_utilizador, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
