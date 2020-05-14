using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class ModulosServices : IModulosServices
    {
        private IRepository<Modulos> _modulosRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="modulosRepository"></param>
        public ModulosServices(IRepository<Modulos> modulosRepository)
        {
            _modulosRepository = modulosRepository;
        }

        public Task<DataBase.ViewModels.Modulos> CreateAsync(DataBase.Models.Modulos modulos, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<DataBase.ViewModels.Modulos>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Modulos> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public Task<DataBase.ViewModels.Modulos> UpdateAsync(int id, DataBase.Models.Modulos modulos, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
