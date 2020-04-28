using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interfce do Gateway dos Internamentos
    public interface IInternamento
    {
        /// <summary>
        /// Criar Internamento
        /// </summary>
        /// <param name="internamento"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Internamento> CreateAsync(DataBase.Models.Internamento internamento, CancellationToken ct);
        /// <summary>
        /// Update Internamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="internamento"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Internamento> UpdateAsync(int id, DataBase.Models.Internamento internamento, CancellationToken ct);
        /// <summary>
        /// Obter o Internamento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Internamento> GetByIdAsync(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Internamentos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Internamento>> GetAllAsync(CancellationToken ct);
        /// <summary>
        /// Apagar o Internamento pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken ct);

    }
}
