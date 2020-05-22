using Business.Interfaces;
using DataBase.Repository;
using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using DataBase.RequestModel;

namespace Business
{
    public class Profissionais_SaudeServices : IProfissionais_SaudeServices
    {
        /// <summary>
        /// Logica do negócio - Serviços para os Profissionais de Saude
        /// </summary>
        private IRepository<Profissionais_Saude> _profissionais_saudeRepository;
        private IUtilizadoresServices _utilizadoresServices;
        private IPerfil_UtilizadoresServices _perfil_utilizadoresServices;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="profissionais_saudeRepository"></param>
        public Profissionais_SaudeServices(
            IRepository<Profissionais_Saude> profissionais_saudeRepository,
            IUtilizadoresServices utilizadoresServices,
            IPerfil_UtilizadoresServices perfil_utilizadoresServices
        )
        {
            _profissionais_saudeRepository = profissionais_saudeRepository;
            _utilizadoresServices = utilizadoresServices;
            _perfil_utilizadoresServices = perfil_utilizadoresServices;
        }

        /// <summary>
        /// Serviço para a criação dos profissionais de saude
        /// </summary>
        /// <param name="profissionais_saude">Identificador para a criação na base de dados</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do doente criado</returns>
        public async Task<Profissionais_Saude> CreateAsync(ProfissionalSaudeRequest profissionais_saude, CancellationToken ct)
        {
            try
            {
                var perfis = await _perfil_utilizadoresServices.GetAllAsync(ct);
                var utilizador = await _utilizadoresServices.CreateAsync(new Utilizadores()
                {
                    Id_Perfil_Utilizador = perfis.ToList().Where(x => x.Nome == profissionais_saude.Profissao).Select(x => x.Id).SingleOrDefault(),
                    Nome = profissionais_saude.Nome,
                    Idade = profissionais_saude.Idade,
                    Morada = profissionais_saude.Morada,
                    NIB = profissionais_saude.NIB,
                    CC = profissionais_saude.CC,
                    Sexo = profissionais_saude.Sexo,
                    Username = profissionais_saude.CC.ToString()
                }, ct);

                var result = await _profissionais_saudeRepository.CreateAsync(new Profissionais_Saude()
                {
                    Id_Utilizador = utilizador.Id,
                    Id_Hospital = profissionais_saude.Id_Hospital,
                    Profissao = profissionais_saude.Profissao
                }, ct);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do profissional de saude. Verifique se os perfis de utilizador para a profissão associada ao profissional de saude estão configurados", e);
            }
        }

        /// <summary>
        /// Serviço para a remoçao de um Profissional de Saude
        /// </summary>
        /// <param name="id">Identificador de um profissional de saude</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var profissional = await _profissionais_saudeRepository.GetAsync(id, ct);
                await _profissionais_saudeRepository.DeleteAsync(profissional, ct);
                await _utilizadoresServices.DeleteAsync(profissional.Id_Utilizador, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao eliminar o profissional de saúde e o respectivo utilizador.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtenção de um profissional de saude
        /// </summary>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>Lista de profissionais de saude</returns>
        public async Task<ICollection<Profissionais_Saude>> GetAllAsync(CancellationToken ct)
        {
            try
            {
                return await _profissionais_saudeRepository.GetAllAsync(ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao obter a lista de profissionais de saúde.", e);
            }
        }

        /// <summary>
        /// Serviço para a obtençao de um profissional de saude
        /// </summary>
        /// <param name="id">Identificador de um profissional de saude</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do profissional de saude</returns>
        public async Task<Profissionais_Saude> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _profissionais_saudeRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao obter a lista de doentes.", e);
            }
        }

        /// <summary>
        /// Serviço para a atualização dos dados de um profssional de saude
        /// </summary>
        /// <param name="id">Identificador do profissional de saude</param>
        /// <param name="profissionais_saude">Dados do profissional de saude para gravar</param>
        /// <param name="ct">Cancellation Token - chamada asincrona</param>
        /// <returns>View do profissional de saude</returns>
        public async Task<Profissionais_Saude> UpdateAsync(int id, ProfissionalSaudeRequest profissionais_saude, CancellationToken ct)
        {
            try
            {
                var profissionalObject = await _profissionais_saudeRepository.GetAsync(id, ct);
                var utilizador = await _utilizadoresServices.GetByIdAsync(profissionalObject.Id_Utilizador, ct);

                utilizador.Nome = profissionais_saude.Nome;
                utilizador.Idade = profissionais_saude.Idade;
                utilizador.Morada = profissionais_saude.Morada;
                utilizador.NIB = profissionais_saude.NIB;
                utilizador.CC = profissionais_saude.CC;
                utilizador.Sexo = profissionais_saude.Sexo;
                utilizador.Username = profissionais_saude.CC.ToString();

                profissionalObject.Id_Hospital = profissionais_saude.Id_Hospital;
                profissionalObject.Profissao = profissionais_saude.Profissao;

                var result = await _profissionais_saudeRepository.UpdateAsync(profissionalObject, ct);
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
