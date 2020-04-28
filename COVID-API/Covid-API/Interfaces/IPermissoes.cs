using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface do Gatewasy das Permissoes
    public interface IPermissoes
    { 
        /// <summary>
        /// Criar Permissao
        /// </summary>
        /// <param name="permissoes"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Permissoes> CreateAsync(DataBase.Models.Permissoes permissoes, CancellationToken ct);
        /// <summary>
        /// Update Permissao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissoes"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Permissoes> UpdateAsync(int id, DataBase.Models.Permissoes permissoes, CancellationToken ct);
        /// <summary>
        /// Obter Permissao pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Permissoes> GetByIdAsync(int id, CancellationToken ct);
        /// <summary>
        /// Listar todas as Permissoes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Permissoes>> GetAllAsync(CancellationToken ct);
        /// <summary>
        /// Apagar a Permissao pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
