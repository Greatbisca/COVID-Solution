﻿using DataBase.Models;
using DataBase.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    /// <summary>
    /// Lógica de negócio - Serviço para os Profissionais de Saúde
    /// </summary>
    public interface IProfissionais_SaudeServices
    {
        /// <summary>
        /// Serviço para a criação de um profissional de saude
        /// </summary>
        /// <param name="profissionais_saude"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Profissionais_Saude> CreateAsync(
            ProfissionalSaudeRequest profissionais_saude,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para atualização dos Profissionais de Saude
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profissionais_saude"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Profissionais_Saude> UpdateAsync(
            int id,
            ProfissionalSaudeRequest profissionais_saude,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtençao de um profissional de Saude, por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<Profissionais_Saude> GetByIdAsync(
            int id,
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a obtenção da lista de Profissionais de Saude
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<ICollection<Profissionais_Saude>> GetAllAsync(
            CancellationToken ct
        );

        /// <summary>
        /// Serviço para a eliminação de um Profissional de Saude, por id
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