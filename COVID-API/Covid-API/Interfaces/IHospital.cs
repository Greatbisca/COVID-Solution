using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Covid_API.Interfaces
{
    //interface do Gatway do Hospital
    public interface IHospital
    {
        /// <summary>
        /// Criar Hospital
        /// </summary>
        /// <param name="hospital"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Hospital> Create(DataBase.Models.Hospital hospital, CancellationToken ct);

        /// <summary>
        /// Update Hospital
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hospital"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Hospital> Update(int id, DataBase.Models.Hospital hospital, CancellationToken ct);

        /// <summary>
        /// Obter o Hospital pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<DataBase.ViewModels.Hospital> GetById(int id, CancellationToken ct);

        /// <summary>
        /// Listar todos os Hospitais
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<DataBase.ViewModels.Hospital>> GetAll(CancellationToken ct);

        /// <summary>
        /// Apagar o Hospital pelo ID 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task Delete(int id, CancellationToken ct);
    }
}
