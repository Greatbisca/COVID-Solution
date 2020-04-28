using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface do Gateway dos Doentes
    public interface IDoente
    {
        /// <summary>
        /// Criar Doente
        /// </summary>
        /// <param name="doente"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Doente> CreateAsync(DataBase.Models.Doente doente, CancellationToken ct);
        /// <summary>
        /// Update Doente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="doente"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Doente> UpdateAsync(int id, DataBase.Models.Doente doente, CancellationToken ct);
        /// <summary>
        /// Obter o Doente pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Doente> GetByIdAsync(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Doentes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Doente>> GetAllAsync(CancellationToken ct);
        /// <summary>
        /// Apagar o Doente pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
