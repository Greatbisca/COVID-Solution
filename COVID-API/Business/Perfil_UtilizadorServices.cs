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
    public class Perfil_UtilizadorServices : IPerfil_UtilizadoresServices
    {
        private IRepository<Perfil_Utilizador> _perfil_utilizadorRepository;
        private IPermissoesServices _permissoesServices;
        private IModulosServices _modulosServices;

        /// <summary>
        /// Construtor do Dependency Injection
        /// </summary>
        /// <param name="perfil_utilizadorRepository"></param>
        public Perfil_UtilizadorServices(
            IRepository<Perfil_Utilizador> perfil_utilizadorRepository,
            IPermissoesServices permissoesServices,
            IModulosServices modulosServices
        )
        {
            _perfil_utilizadorRepository = perfil_utilizadorRepository;
            _permissoesServices = permissoesServices;
            _modulosServices = modulosServices;
        }

        /// <summary>
        /// Serviço para a criação de Perfil Utilizador
        /// </summary>
        /// <param name="perfil_utilizador">Objeto Perfil Utilizador para a criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do Perfil Utilizador</returns>
        public async Task<Perfil_Utilizador> CreateAsync(Perfil_Utilizador perfil_utilizador, CancellationToken ct)
        {
            try
            {
                var perfil = await _perfil_utilizadorRepository.CreateAsync(perfil_utilizador, ct);
                var modulos = await _modulosServices.GetAllAsync(ct);

                foreach(var modulo in modulos)
                {
                    await _permissoesServices.CreateAsync(new Permissoes()
                    {
                        Id_Modulo = modulo.Id,
                        Id_Perfil_Utilizador = perfil.Id
                    }, ct);
                }

                return perfil;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do perfil de utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a remoçao do Perfil Utilizador
        /// </summary>
        /// <param name="id">Identificador do Perfil Utilizador</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var permissoes = await _permissoesServices.GetAllAsync(ct);
                foreach(var permissao in permissoes.Where(p => p.Id_Perfil_Utilizador == id))
                {
                    await _permissoesServices.DeleteAsync(permissao.Id, ct);
                }

                var perfil_utilizador = await _perfil_utilizadorRepository.GetAsync(id, ct);
                await _perfil_utilizadorRepository.DeleteAsync(perfil_utilizador, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na eliminação do perfil de utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a lista de Perfil Utilizadores
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de Perfil Utilizadores</returns>
        public async Task<ICollection<Perfil_Utilizador>> GetAllAsync(CancellationToken ct)
        {
            try
            {
                return await _perfil_utilizadorRepository.GetAllAsync(ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção da lista de perfis de utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtençao do Perfil Utilizador
        /// </summary>
        /// <param name="id">Identificador do Perfil Utilizador</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do Perfil Utilzador</returns>
        public async Task<Perfil_Utilizador> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _perfil_utilizadorRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do perfil de utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a atualizaçao dos dados de um perfil utilizador
        /// </summary>
        /// <param name="id">Identificador do perfil utilizador</param>
        /// <param name="perfil_utilizador">Dados do perfil utilizador para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do perfil utilizador</returns>
        public async Task<Perfil_Utilizador> UpdateAsync(int id, Perfil_Utilizador perfil_utilizador, CancellationToken ct)
        {
            try
            {
                var perfil_utilizadorObject = await _perfil_utilizadorRepository.GetAsync(id, ct);
                perfil_utilizadorObject.Nome = perfil_utilizador.Nome;

                return await _perfil_utilizadorRepository.UpdateAsync(perfil_utilizadorObject, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do perfil de utilizador.", e);
            }
        }
    }
}
