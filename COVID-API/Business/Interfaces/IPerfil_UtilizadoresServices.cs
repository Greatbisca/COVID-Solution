using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviços para os Perfis de Utilizadores 
    /// </summary>
    public interface IPerfil_UtilizadoresServices
    {
       /// <summary>
       /// Serviço de criação de um perfil de utilizador
       /// </summary>
       /// <param name="perfil_utilizador"></param>
       /// <param name="ct"></param>
       /// <returns></returns>
        Task<DataBase.ViewModels.Perfil_Utilizador> CreateAsync(
            DataBase.Models.Perfil_Utilizador perfil_utilizador,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a actualização dos dados de um Perfil de Utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="perfil_utilizador"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Perfil_Utilizador> UpdateAsync(
            int id,
            DataBase.Models.Perfil_Utilizador perfil_utilizador,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção dos dados de um Perfil de Utilizador, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Perfil_Utilizador> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção da lista de Perfil de Utilizador
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Perfil_Utilizador>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um perfil de Utilizador, por id
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
