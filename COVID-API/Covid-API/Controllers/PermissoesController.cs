using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Interfaces;
using Covid_API.Interfaces;
using Covid_API.Mappings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Covid_API.Controllers
{
    [Route("api/permissoes")]
    [ApiController]
    public class PermissoesController : ControllerBase, IPermissoes
    {
        private IPermissoesServices _permissoesServices;
        private IModulosServices _modulosServices;
        private IPerfil_UtilizadoresServices _perfil_utilizadoresServices;

        /// <summary>
        /// Construtor com dependency injection
        /// </summary>
        /// <param name="permissoesServices"></param>
        public PermissoesController(
            IPermissoesServices permissoesServices,
            IModulosServices modulosServices,
            IPerfil_UtilizadoresServices perfil_UtilizadoresServices
        )
        {
            _permissoesServices = permissoesServices;
            _modulosServices = modulosServices;
            _perfil_utilizadoresServices = perfil_UtilizadoresServices;
        }

        /// <summary>
        /// Endpoint para a criação de uma permissao
        /// </summary>
        /// <param name="permissoes">Objecto para gravar na base de dados</param>
        /// <param name="ct"></param>
        /// <returns>View da permissao criada</returns>
        [HttpPost]
        [Route("")]
        public async Task<DataBase.ViewModels.Permissoes> CreateAsync(
            [FromBody] DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        )
        {
            var result = await _permissoesServices.CreateAsync(permissoes, ct);
            var perfil = await _perfil_utilizadoresServices.GetByIdAsync(result.Id_Perfil_Utilizador, ct);
            var modulo = await _modulosServices.GetByIdAsync(result.Id_Modulo, ct);

            return result.ToViewModel(modulo, perfil);
        }

        /// <summary>
        /// Endpoint para a eliminação de uma permissao
        /// </summary>
        /// <param name="id">Identificador da permissao a eliminar</param>
        /// <param name="ct"></param>
        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            await _permissoesServices.DeleteAsync(id, ct);
        }

        /// <summary>
        /// Endpoint para a obtenção da lista de permissoes
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ICollection<DataBase.ViewModels.Permissoes>> GetAllAsync(CancellationToken ct)
        {
            var result = await _permissoesServices.GetAllAsync(ct);
            var resultList = new List<DataBase.ViewModels.Permissoes>();

            foreach(var permissao in result)
            {
                var modulo = await _modulosServices.GetByIdAsync(permissao.Id_Modulo, ct);
                var perfil = await _perfil_utilizadoresServices.GetByIdAsync(permissao.Id_Perfil_Utilizador, ct);

                resultList.Add(permissao.ToViewModel(modulo, perfil));
            }

            return resultList;
        }

        /// <summary>
        /// Endpoint para a obtenção de uma permissao por Id
        /// </summary>
        /// <param name="id">Identificador da permissao</param>
        /// <param name="ct"></param>
        /// <returns>View da permissao</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Permissoes> GetByIdAsync(
            [FromRoute] int id,
            CancellationToken ct
        )
        {
            var result = await _permissoesServices.GetByIdAsync(id, ct);
            var modulo = await _modulosServices.GetByIdAsync(result.Id_Modulo, ct);
            var perfil = await _perfil_utilizadoresServices.GetByIdAsync(result.Id_Perfil_Utilizador, ct);

            return result.ToViewModel(modulo, perfil);
        }

        /// <summary>
        /// Endpoint para a atualização de uma permissao 
        /// </summary>
        /// <param name="id">Indentificador de uma permissao</param>
        /// <param name="permissoes">Dados da permissao para atualização</param>
        /// <param name="ct"></param>
        /// <returns>View da permissao atualizada</returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<DataBase.ViewModels.Permissoes> UpdateAsync(
            [FromRoute] int id,
            [FromBody] DataBase.Models.Permissoes permissoes,
            CancellationToken ct
        )
        {
            var result = await _permissoesServices.UpdateAsync(id, permissoes, ct);
            var modulo = await _modulosServices.GetByIdAsync(result.Id_Modulo, ct);
            var perfil = await _perfil_utilizadoresServices.GetByIdAsync(result.Id_Perfil_Utilizador, ct);

            return result.ToViewModel(modulo, perfil);
        }
    }
}