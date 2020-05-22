using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Logica do Negocio - Serviços para os teste
    /// </summary>
    public class TesteServices : ITesteServices
    {
        private IRepository<Teste> _testeRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="testeRepository"></param>
        public TesteServices(IRepository<Teste> testeRepository)
        {
            _testeRepository = testeRepository;
        }

        /// <summary>
        /// Serviço para a criação do teste
        /// </summary>
        /// <param name="teste">Objeto Teste para a criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do teste criado</returns>
        public async Task<Teste> CreateAsync(Teste teste, CancellationToken ct)
        {
            try
            {
                return await _testeRepository.CreateAsync(teste, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do teste.", e);
            }
        }

        /// <summary>
        /// Serviço para a remoção de um teste
        /// </summary>
        /// <param name="id">Identificador do teste</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var teste = await _testeRepository.GetAsync(id, ct);
                await _testeRepository.DeleteAsync(teste, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na eliminação do teste.", e);
            }
        }

        /// <summary>
        /// Serviço para a lista de testes
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de Testes</returns>
        public async Task<ICollection<Teste>> GetAllAsync(CancellationToken ct)
        {
            try
            {
                return await _testeRepository.GetAllAsync(ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção da lista do teste.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtenção de um teste
        /// </summary>
        /// <param name="id">Identificador de um teste</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do teste</returns>
        public async Task<Teste> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _testeRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do teste.", e);
            }
        }

        /// <summary>
        /// Serviço para o atualização dos dados de um teste
        /// </summary>
        /// <param name="id">Identificador do teste</param>
        /// <param name="teste">Dados do teste para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do teste</returns>
        public async Task<Teste> UpdateAsync(int id, Teste teste, CancellationToken ct)
        {
            try
            {
                var testeObject = await _testeRepository.GetAsync(id, ct);

                testeObject.Data_Teste = teste.Data_Teste;
                testeObject.Id_Doente = teste.Id_Doente;
                testeObject.Id_Profissional = teste.Id_Profissional;
                testeObject.Resultado_Teste = teste.Resultado_Teste;
                testeObject.Tipo_Teste = teste.Tipo_Teste;

                return await _testeRepository.UpdateAsync(testeObject, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na actualização do teste.", e);
            }
        }
    }
}
