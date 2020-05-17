using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviço para os Testes
    /// </summary>
    public interface ITesteServices
    {
        /// <summary>
        /// Serviço para a criação de um teste
        /// </summary>
        /// <param name="teste"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Teste> CreateAsync(
            Teste teste,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a atualização dos dados de um teste
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teste"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Teste> UpdateAsync(
            int id,
            Teste teste,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção dos dados de um teste, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Teste> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção da lista de testes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<Teste>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um teste, por id
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
