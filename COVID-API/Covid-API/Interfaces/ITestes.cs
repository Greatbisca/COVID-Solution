using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface do Gateway dos Testes
    public interface ITestes
    {
        /// <summary>
        /// Criar Teste
        /// </summary>
        /// <param name="teste"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Teste> CreateAsync(DataBase.Models.Teste teste, CancellationToken ct);
        /// <summary>
        /// Update Teste
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teste"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Teste> UpdateAsync(int id, DataBase.Models.Teste teste, CancellationToken ct);
        /// <summary>
        /// Obter o Teste pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Teste> GetByIdAsync(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Testes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Teste>> GetAllAsync(CancellationToken ct);
        /// <summary>
        /// Apagar o Teste pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken ct);

    }
}
