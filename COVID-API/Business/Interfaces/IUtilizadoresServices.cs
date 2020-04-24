using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviço para os Utilizadores 
    /// </summary>
    public interface IUtilizadoresServices
    {
        /// <summary>
        /// Serviço de criação de um utilizador
        /// </summary>
        /// <param name="utilizadores"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Utilizadores> CreateAsync(
            DataBase.Models.Utilizadores utilizadores,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço de atualização de dados de um utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilizadores"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Utilizadores> UpdateAsync(
            int id,
            DataBase.Models.Utilizadores utilizadores,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção dos dados de um utilizador, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Utilizadores> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção da lista de utilizadores
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Utilizadores>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um utilizador, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(
            int id,
            CancellationToken ct
        );
    }
}
