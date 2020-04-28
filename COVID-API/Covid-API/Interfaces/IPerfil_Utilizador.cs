using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface do Gateway dos Perfis de Utilizador
    public interface IPerfil_Utilizador
    {
        /// <summary>
        /// Criar Perfil de Utilizador
        /// </summary>
        /// <param name="perfil_utilizador"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Perfil_Utilizador> CreateAsync(DataBase.Models.Perfil_Utilizador perfil_utilizador, CancellationToken ct);
        /// <summary>
        /// Update Perfil de Utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="perfil_utilizador"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Perfil_Utilizador> UpdateAsync(int id, DataBase.Models.Perfil_Utilizador perfil_utilizador, CancellationToken ct);
        /// <summary>
        /// Obter o Perfil de Utilizador pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Perfil_Utilizador> GetByIdAsync(int id, CancellationToken ct);
        /// <summary>
        /// Listar todos os Perfis de Utilizadores
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Perfil_Utilizador>> GetAllAsync(CancellationToken ct);
        /// <summary>
        /// Apagar o Perfil de Utilizador pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken ct);
    }
}
