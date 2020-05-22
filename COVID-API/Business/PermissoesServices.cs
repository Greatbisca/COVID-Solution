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
    public class PermissoesServices : IPermissoesServices
    {
        private IRepository<Permissoes> _permissoesRepository;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="permissoesRepository"></param>
        public PermissoesServices(IRepository<Permissoes> permissoesRepository)
        {
            _permissoesRepository = permissoesRepository;
        }

        /// <summary>
        /// Serviço para a criação de permissao
        /// </summary>
        /// <param name="permissoes">Objeto Permissao para a criaçao na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View da permissao criada</returns>
        public async Task<Permissoes> CreateAsync(Permissoes permissoes, CancellationToken ct)
        {
            try
            {
                return await _permissoesRepository.CreateAsync(permissoes, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na criação da permissão.", e);
            }
        }

        /// <summary>
        /// Serviço para a remoçao de uma permissao
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var permissao = await _permissoesRepository.GetAsync(id, ct);
                await _permissoesRepository.DeleteAsync(permissao, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na eliminação da permissão.", e);
            }
        }

        /// <summary>
        /// Serviço para a lista de permissoes
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de permissoes</returns>
        public async Task<ICollection<Permissoes>> GetAllAsync(CancellationToken ct)
        {
            try
            {
                return await _permissoesRepository.GetAllAsync(ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção da lista de permissoes.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtençao de uma permissao
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View da permissao</returns>
        public async Task<Permissoes> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _permissoesRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção da permissao.", e);
            }
        }

        /// <summary>
        /// Serviço para a atualização de dados de uma permiçao
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="permissoes">Dados da permissao para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View da permissao</returns>
        public async Task<Permissoes> UpdateAsync(int id, Permissoes permissoes, CancellationToken ct)
        {
            try
            {
                var permissao = await _permissoesRepository.GetAsync(id, ct);

                permissao.Criar = permissoes.Criar;
                permissao.Eliminar = permissoes.Eliminar;
                permissao.Escrever = permissoes.Escrever;
                permissao.Id_Modulo = permissoes.Id_Modulo;
                permissao.Id_Perfil_Utilizador = permissoes.Id_Perfil_Utilizador;
                permissao.Ler = permissoes.Ler;

                return await _permissoesRepository.UpdateAsync(permissao, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na actualização da permissao.", e);
            }
        }
    }
}
