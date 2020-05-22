using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    public class UtilizadoresServices : IUtilizadoresServices
    {
        private IRepository<Utilizadores> _utilizadoresRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="internamentoRepository"></param>
        public UtilizadoresServices(IRepository<Utilizadores> utilizadoresRepository)
        {
            _utilizadoresRepository = utilizadoresRepository;
        }

        /// <summary>
        /// Serviço para a criação do utilizador
        /// </summary>
        /// <param name="utilizador"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<Utilizadores> CreateAsync(Utilizadores utilizador, CancellationToken ct)
        {
            try
            {
                return await _utilizadoresRepository.CreateAsync(utilizador, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a eliminação do utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var utilizador = await _utilizadoresRepository.GetAsync(id, ct);
                await _utilizadoresRepository.DeleteAsync(utilizador, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na eliminação do utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtenção do utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<Utilizadores> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _utilizadoresRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a actualização do utilizador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="utilizador"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<Utilizadores> UpdateAsync(int id, Utilizadores utilizador, CancellationToken ct)
        {
            try
            {
                var utilizadorObject = await _utilizadoresRepository.GetAsync(id, ct);

                utilizadorObject.CC = utilizador.CC;
                utilizadorObject.Idade = utilizador.Idade;
                utilizadorObject.Id_Perfil_Utilizador = utilizador.Id_Perfil_Utilizador;
                utilizadorObject.Morada = utilizador.Morada;
                utilizadorObject.NIB = utilizador.NIB;
                utilizadorObject.Nome = utilizador.Nome;
                utilizadorObject.Sexo = utilizador.Sexo;
                utilizadorObject.Username = utilizador.Username;

                return await _utilizadoresRepository.UpdateAsync(utilizadorObject, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na actualização do utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para o login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<string> ValidateLoginAsync(string username, string password, CancellationToken ct)
        {
            try
            {
                var utilizadores = await _utilizadoresRepository.GetAllAsync(ct);

                if (!utilizadores.Any(x => x.Username == username))
                {
                    throw new Exception("Username ou password errados");
                }

                return "OAUTH ACCESS TOKEN";
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na actualização do utilizador.", e);
            }
        }
    }
}
