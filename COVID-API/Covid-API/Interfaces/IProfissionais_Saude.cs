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
        Task<DataBase.ViewModels.Profissionais_Saude> Create(DataBase.Models.Profissionais_Saude profissionais, CancellationToken ct);

        /// <summary>
        /// Update do Profissional de Saude
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profissionais"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Profissionais_Saude> Update(int id, DataBase.Models.Profissionais_Saude profissionais, CancellationToken ct);

        /// <summary>
        /// Obter um Profissional pelo seu respetivo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profissionais"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Profissionais_Saude> GetById(int id, DataBase.ViewModels.Profissionais_Saude profissionais, CancellationToken ct);

        /// <summary>
        /// Obter todos os Profissionais de Saude
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Profissionais_Saude> GetAll(CancellationToken ct);

        Task Delete(int id, CancellationToken ct);
    }
}
