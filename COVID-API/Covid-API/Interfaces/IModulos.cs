using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface do Gateway dos Modulos
    public interface IModulos
    {
        /// <summary>
        /// Criar Modulo
        /// </summary>
        /// <param name="modulos"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> CreateAsync(DataBase.Models.Modulos modulos, CancellationToken ct);
        /// <summary>
        /// Update Modulo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modulos"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> UpdateAsync(int id, DataBase.Models.Modulos modulos, CancellationToken ct);
        /// <summary>
        /// Obter Modulo por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> GetByIdAsync(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Modulos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Modulos>> GetAllAsync(CancellationToken ct);
        /// <summary>
        /// Apagar o modulo pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
