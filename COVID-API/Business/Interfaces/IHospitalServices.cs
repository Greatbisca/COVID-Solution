﻿using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Logica de ne~gócio - Serviços para os hospitais
    /// </summary>
    public interface IHospitalServices
    {
        /// <summary>
        /// Serviço para a criação de um hospital
        /// </summary>
        /// <param name="hospital"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Hospital> CreateAsync(
            Hospital hospital,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a atualizacao de dados de um hospital
        /// </summary>
        /// <param name="id"></param>
        /// <param name="hospital"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Hospital> UpdateAsync(
            int id,
            Hospital hospital,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção de dados de um hospital, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Hospital> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtençao da lista de hospitais
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<Hospital>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um hospital, por id
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
