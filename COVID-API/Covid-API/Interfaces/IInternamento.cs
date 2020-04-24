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
        Task<DataBase.ViewModels.Internamento> Create(DataBase.Models.Internamento internamento, CancellationToken ct);
        /// <summary>
        /// Update Internamento
        /// </summary>
        /// <param name="id"></param>
        /// <param name="internamento"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Internamento> Update(int id, DataBase.Models.Internamento internamento, CancellationToken ct);
        /// <summary>
        /// Obter o Internamento por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Internamento> GetById(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Internamentos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Internamento>> GetAll(CancellationToken ct);
        /// <summary>
        /// Apagar o Internamento pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task Delete(int id, CancellationToken ct);

    }
}
