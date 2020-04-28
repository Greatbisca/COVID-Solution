using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //Interface Gateway do Profissionais de Saude
    public interface IProfissionais_Saude
    {
        /// <summary>
        /// Criar um Profissional de Saude
        /// </summary>
        /// <param name="profissionais"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Profissionais_Saude> CreateAsync(DataBase.Models.Profissionais_Saude profissionais, CancellationToken ct);

        /// <summary>
        /// Update do Profissional de Saude
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profissionais"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Profissionais_Saude> UpdateAsync(int id, DataBase.Models.Profissionais_Saude profissionais, CancellationToken ct);

        /// <summary>
        /// Obter um Profissional pelo seu respetivo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profissionais"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Profissionais_Saude> GetByIdAsync(int id, CancellationToken ct);

        /// <summary>
        /// Obter todos os Profissionais de Saude
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Profissionais_Saude>> GetAllAsync(CancellationToken ct);

        Task DeleteAsync(int id, CancellationToken ct);
    }
}
