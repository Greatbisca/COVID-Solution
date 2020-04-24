using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviços para os modulos
    /// </summary>
    public interface IModulosServices
    {
        /// <summary>
        /// Serviço para a criação de um modulo
        /// </summary>
        /// <param name="modulos"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> CreateAsync(
            DataBase.Models.Modulos modulos,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a atualização de dados de um doente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modulos"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> UpdateAsync(
        int id,
        DataBase.Models.Modulos modulos,
        CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção de um modulo, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção da lista de Modulos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Modulos>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um modulo, por id
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
