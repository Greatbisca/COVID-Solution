using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Lógica de negócio - Serviços para os doentes
    /// </summary>
    public class DoenteServices : IDoenteServices
    {
        private IRepository<Doente> _doenteRepository;
        private IUtilizadoresServices _utilizadoresServices;
        private IPerfil_UtilizadoresServices _perfil_utilizadoresServices;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="doenteRepository"></param>
        public DoenteServices(
            IRepository<Doente> doenteRepository,
            IUtilizadoresServices utilizadoresServices,
            IPerfil_UtilizadoresServices perfil_utilizadoresServices
        )
        {
            _doenteRepository = doenteRepository;
            _utilizadoresServices = utilizadoresServices;
            _perfil_utilizadoresServices = perfil_utilizadoresServices;
        }

        /// <summary>
        /// Serviço para a criação de doente. No modelo de dados, o doente extende o utilizador.
        /// </summary>
        /// <param name="doente">Objecto Doente para criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente criado</returns>
        public async Task<Doente> CreateAsync(
            DataBase.RequestModel.DoenteRequest doente, 
            CancellationToken ct
        )
        {
            try
            {
                var perfis = await _perfil_utilizadoresServices.GetAllAsync(ct);
                var utilizador = await _utilizadoresServices.CreateAsync(new Utilizadores()
                {
                    Id_Perfil_Utilizador = perfis.ToList().Where(x => x.Nome == "Doente").Select(x => x.Id).SingleOrDefault(),
                    Nome = doente.Nome,
                    Idade = doente.Idade,
                    Morada = doente.Morada,
                    NIB = doente.NIB,
                    CC = doente.CC,
                    Sexo = doente.Sexo,
                    Username = doente.CC.ToString()
                }, ct);

                var result = await _doenteRepository.CreateAsync(new Doente()
                {
                    Id_Utilizador = utilizador.Id,
                    Regiao = doente.Regiao
                }, ct);

                return result;
            } catch(Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do doente. Verifique se os perfis de utilizador para os doentes estão configurados", e);
            }
            
        }

        /// <summary>
        /// Serviço para a remoção de um doente
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public async Task DeleteAsync(
            int id, 
            CancellationToken ct
        )
        {
            try
            {
                var doente = await _doenteRepository.GetAsync(id, ct);
                var utilizadorid = doente.Id_Utilizador;
                await _doenteRepository.DeleteAsync(doente, ct);
               // await _utilizadoresServices.DeleteAsync(utilizadorid, ct);
            } catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao eliminar o doente e o respectivo utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a lista de doentes
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de doentes</returns>
        public async Task<ICollection<Doente>> GetAllAsync(
            CancellationToken ct
        )
        {
            try
            {
                return await _doenteRepository.GetAllAsync(ct);
            } catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao obter a lista de doentes.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtenção de um doente
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente</returns>
        public async Task<Doente> GetByIdAsync(
            int id, 
            CancellationToken ct
        )
        {
            try
            {
                return await _doenteRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao obter a lista de doentes.", e);
            }
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um doente
        /// </summary>
        /// <param name="id">Identificador do doente</param>
        /// <param name="doente">Dados do doente para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente</returns>
        public async Task<Doente> UpdateAsync(
            int id,
            DataBase.RequestModel.DoenteRequest doente, 
            CancellationToken ct
        )
        {
            try
            {
                var doenteObject = await _doenteRepository.GetAsync(id, ct);
                var utilizador = await _utilizadoresServices.GetByIdAsync(doenteObject.Id_Utilizador, ct);

                utilizador.Nome = doente.Nome;
                utilizador.Idade = doente.Idade;
                utilizador.Morada = doente.Morada;
                utilizador.NIB = doente.NIB;
                utilizador.CC = doente.CC;
                utilizador.Sexo = doente.Sexo;
                utilizador.Username = doente.CC.ToString();

                doenteObject.Regiao = doente.Regiao;

                var result = await _doenteRepository.UpdateAsync(doenteObject, ct);
                await _utilizadoresServices.UpdateAsync(utilizador.Id, utilizador, ct);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na actualização do doente e respectivo utilizador.", e);
            }
        }
    }
}
