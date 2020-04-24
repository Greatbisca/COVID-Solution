using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface do Gateway dos Utilizadores
    public interface IUtilizadores
    {
        /// <summary>
        /// Criar Utilizador
        /// </summary>
        /// <param name="utilizadores"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Utilizadores> Create(DataBase.Models.Utilizadores utilizadores, CancellationToken ct);
        /// <summary>
        /// Update Utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilizadores"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Utilizadores> Update(int id, DataBase.Models.Utilizadores utilizadores, CancellationToken ct);
        /// <summary>
        /// Obter Utilizador pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Utilizadores> GetById(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Utilizadores
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Utilizadores>> GetAll(CancellationToken ct);
        /// <summary>
        /// Apagar o Utilizador pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task Delete(int id, CancellationToken ct);

    }
}
