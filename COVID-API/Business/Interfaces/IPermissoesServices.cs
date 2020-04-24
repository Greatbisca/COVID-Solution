using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviços para as Permissoes
    /// </summary>
    public interface IPermissoesServices
    {
     
        /// <summary>
        /// Serviços de criacao de permissoes
        /// </summary>
        /// <param name="permissoes"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Permissoes> CreateAsync(
            DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        );

     
        /// <summary>
        /// Serviço para a atualização dos dados de uma permissao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="permissoes"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Permissoes> UpdateAsync(
            int id,
            DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        );


        /// <summary>
        /// Serviço para a obtenção dos dados de uma permissao, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Permissoes> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção da lista de permissoes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Permissoes>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de uma permissao, por id
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
