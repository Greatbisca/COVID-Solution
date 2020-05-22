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
    public class ModulosServices : IModulosServices
    {
        private IRepository<Modulos> _modulosRepository;
        private IPerfil_UtilizadoresServices _perfil_UtilizadoresServices;
        private IPermissoesServices _permissoesServices;

        /// <summary>
        /// Construtor com Dependency Injection
        /// </summary>
        /// <param name="modulosRepository"></param>
        public ModulosServices(
            IRepository<Modulos> modulosRepository,
            IPermissoesServices permissoesServices,
            IPerfil_UtilizadoresServices perfil_UtilizadoresServices
        )
        {
            _modulosRepository = modulosRepository;
            _permissoesServices = permissoesServices;
            _perfil_UtilizadoresServices = perfil_UtilizadoresServices;
        }

        public async Task<Modulos> CreateAsync(Modulos modulos, CancellationToken ct)
        {
            try
            {
                var modulo = await _modulosRepository.CreateAsync(modulos, ct);
                var perfis = await _perfil_UtilizadoresServices.GetAllAsync(ct);

                foreach(var perfil in perfis)
                {
                    await _permissoesServices.CreateAsync(new Permissoes()
                    {
                        Id_Modulo = modulo.Id,
                        Id_Perfil_Utilizador = perfil.Id
                    }, ct);
                }

                return modulo;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na criação do modulo.", e);
            }
        }

        public async Task DeleteAsync(int id, CancellationToken ct)
        {
            try
            {
                var permissoes = await _permissoesServices.GetAllAsync(ct);
                foreach(var permissao in permissoes.Where(x => x.Id_Modulo == id))
                {
                    await _permissoesServices.DeleteAsync(permissao.Id, ct);
                }

                var modulo = await _modulosRepository.GetAsync(id, ct);
                await _modulosRepository.DeleteAsync(modulo, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na eliminação do modulo.", e);
            }
        }

        public async Task<ICollection<Modulos>> GetAllAsync(CancellationToken ct)
        {
            try
            {
                return await _modulosRepository.GetAllAsync(ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção da lista de modulos.", e);
            }
        }

        public async Task<Modulos> GetByIdAsync(int id, CancellationToken ct)
        {
            try
            {
                return await _modulosRepository.GetAsync(id, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na obtenção do modulo.", e);
            }
        }

        public async Task<Modulos> UpdateAsync(int id, Modulos modulos, CancellationToken ct)
        {
            try
            {
                var modulo = await _modulosRepository.GetAsync(id, ct);
                modulo.EndPoint = modulos.EndPoint;
                modulo.Nome = modulos.Nome;

                return await _modulosRepository.UpdateAsync(modulo, ct);
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro na actualização do modulo.", e);
            }
        }
    }
}
