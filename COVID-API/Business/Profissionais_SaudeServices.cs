using Business.Interfaces;
using DataBase.Repository;
using DataBase.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class Profissionais_SaudeServices : IProfissionais_SaudeServices
    {
        /// <summary>
        /// Logica do negócio - Serviços para os Profissionais de Saude
        /// </summary>
        private IRepository<Profissionais_Saude> _profissionais_saudeRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="profissionais_saudeRepository"></param>
        public Profissionais_SaudeServices(IRepository<Profissionais_Saude> profissionais_saudeRepository)
        {
            _profissionais_saudeRepository = profissionais_saudeRepository;
        }

        /// <summary>
        /// Serviço para a criação dos profissionais de saude
        /// </summary>
        /// <param name="profissionais_saude">Identificador para a criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente criado</returns>
        public Task<DataBase.ViewModels.Profissionais_Saude> CreateAsync(DataBase.Models.Profissionais_Saude profissionais_saude, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a remoçao de um Profissional de Saude
        /// </summary>
        /// <param name="id">Identificador de um profissional de saude</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public Task DeleteAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtenção de um profissional de saude
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de profissionais de saude</returns>
        public Task<ICollection<DataBase.ViewModels.Profissionais_Saude>> GetAllAsync(CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a obtençao de um profissional de saude
        /// </summary>
        /// <param name="id">Identificador de um profissional de saude</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do profissional de saude</returns>
        public Task<DataBase.ViewModels.Profissionais_Saude> GetByIdAsync(int id, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um profssional de saude
        /// </summary>
        /// <param name="id">Identificador do profissional de saude</param>
        /// <param name="profissionais_saude">Dados do profissional de saude para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do profissional de saude</returns>
        public Task<DataBase.ViewModels.Profissionais_Saude> UpdateAsync(int id, DataBase.Models.Profissionais_Saude profissionais_saude, CancellationToken ct)
        {
            throw new NotImplementedException();
        }
    }
}
