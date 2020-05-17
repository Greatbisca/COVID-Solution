using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GatewayTests
{
    public class PermissoesTest
    {
        IPermissoes gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IPermissoesServices> PermissoesServices = new Mock<IPermissoesServices>();
            Mock<IModulosServices> ModulosServices = new Mock<IModulosServices>();
            Mock<IPerfil_UtilizadoresServices> PerfilUtilizadoresServices = new Mock<IPerfil_UtilizadoresServices>();
            
            //Comportamento para criar Premissoes
            PermissoesServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Permissoes>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Permissoes()
            {
                Id = 1,
                Id_Modulo = 1,
                Id_Perfil_Utilizador = 1,
                Criar = true,
                Eliminar = true,
                Escrever = true,
                Ler = true
            });

            PermissoesServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Permissoes>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Permissoes()
            {
                Id = 1,
                Id_Modulo = 1,
                Id_Perfil_Utilizador = 1,
                Criar = true,
                Eliminar = true,
                Escrever = true,
                Ler = true
            });

            PermissoesServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Permissoes()
            {
                Id = 1,
                Id_Modulo = 1,
                Id_Perfil_Utilizador = 1,
                Criar = true,
                Eliminar = true,
                Escrever = true,
                Ler = true
            });

            PermissoesServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.Models.Permissoes>()
            {
                new DataBase.Models.Permissoes()
                {
                    Id = 1,
                    Id_Modulo = 1,
                    Id_Perfil_Utilizador = 1,
                    Criar = true,
                    Eliminar = true,
                    Escrever = true,
                    Ler = true
                }
            });

            PermissoesServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));

            ModulosServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Modulos()
            {
                Id = 1,
                Nome = "Doentes",
                EndPoint = "api/doentes"
            });

            PerfilUtilizadoresServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Perfil_Utilizador()
            {
                Id = 1,
                Nome = "Profissional de Saúde"
            });

            #endregion
            gateway = new PermissoesController(PermissoesServices.Object, ModulosServices.Object, PerfilUtilizadoresServices.Object);
        }

        [Test]
        public async Task CreateTestAsync() {
            var permissao = await gateway.CreateAsync(new DataBase.Models.Permissoes()
                {
                    Id = 0,
                    Id_Modulo = 1,
                    Id_Perfil_Utilizador = 1,
                    Ler = true,
                    Escrever = true,
                    Eliminar = true,
                    Criar = true
                },
                CancellationToken.None
            );

            Assert.AreEqual(permissao.Perfil, "Profissional de Saúde");
        }


        [Test]
        public async Task UpdateTestAsync() {
            var permissao = await gateway.UpdateAsync(
                1,
                new DataBase.Models.Permissoes()
                {
                    Id = 1,
                    Id_Modulo = 1,
                    Id_Perfil_Utilizador = 1,
                    Ler = true,
                    Escrever = true,
                    Eliminar = true,
                    Criar = true
                },
                CancellationToken.None
            );

            Assert.AreEqual(permissao.Perfil, "Profissional de Saúde");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var permissao = await gateway.GetByIdAsync(1, CancellationToken.None);
            Assert.AreEqual(permissao.Perfil, "Profissional de Saúde");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var permissoes = await gateway.GetAllAsync(CancellationToken.None);
            Assert.IsTrue(permissoes.Any(x => x.Perfil == "Profissional de Saúde"));
        }

        [Test]
        public async Task DeleteTestAsync()
        {
            try
            {
                await gateway.DeleteAsync(
                    1,
                    CancellationToken.None
                );
            }
            catch
            {
                Assert.IsTrue(false);
            }
            finally
            {
                Assert.IsTrue(true);
            }
        }
    }
}
