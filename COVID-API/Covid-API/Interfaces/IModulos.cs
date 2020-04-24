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
        Task<DataBase.ViewModels.Modulos> Create(DataBase.Models.Modulos modulos, CancellationToken ct);
        /// <summary>
        /// Update Modulo
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modulos"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> Update(int id, DataBase.Models.Modulos modulos, CancellationToken ct);
        /// <summary>
        /// Obter Modulo por ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Modulos> GetById(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Modulos
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Modulos>> GetAll(CancellationToken ct);
        /// <summary>
        /// Apagar o modulo pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task Delete(int id, CancellationToken ct);
    }
}
