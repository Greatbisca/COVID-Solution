using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviços para os doentes
    /// </summary>
    public interface IDoenteServices
    {
        /// <summary>
        /// Serviço para a criação de um doente
        /// </summary>
        /// <param name="doente"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Doente> CreateAsync(
            DataBase.Models.Doente doente, 
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a atualização dos dados de um doente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doente"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Doente> UpdateAsync(
            int id,
            DataBase.Models.Doente doente,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção dos dados de um doente, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Doente> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção da lista de doentes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Doente>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um doente, por id
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
