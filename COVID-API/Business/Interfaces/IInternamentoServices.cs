using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviços para os internamento
    /// </summary>
    public interface IInternamentoServices
    {
        /// <summary>
        /// Servico de criação de um internamento
        /// </summary>
        /// <param name="internamento"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Internamento> CreateAsync(
            Internamento internamento,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço de atualização de um internamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="internamento"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Internamento> UpdateAsync(
            int id,
            Internamento internamento,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para obter os dados de um internamento, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Internamento> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtençao da lista de intermanetos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<Internamento>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um internamento, por id
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
