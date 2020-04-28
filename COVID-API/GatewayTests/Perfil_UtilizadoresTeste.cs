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
    public class Perfil_UtilizadoresTeste
    {
        IPerfil_Utilizador gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IPerfil_UtilizadoresServices> Perfil_UtilizadoresServices = new Mock<IPerfil_UtilizadoresServices>();
            //Comportamento para criar o Doente
            Perfil_UtilizadoresServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Perfil_Utilizador>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Perfil_Utilizador()
            {
                Nome = "Diogo Biscaia"
            });

            Perfil_UtilizadoresServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Perfil_Utilizador>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Perfil_Utilizador()
            {
                Nome = "Diogo Biscaia"
            });

            Perfil_UtilizadoresServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Perfil_Utilizador()
            {
                Nome = "Diogo Biscaia"
            });

            Perfil_UtilizadoresServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Perfil_Utilizador>()
            {
                new DataBase.ViewModels.Perfil_Utilizador()
                {
                    Nome = "Diogo Biscaia"
                }
            });

            Perfil_UtilizadoresServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new Perfil_UtilizadorController(Perfil_UtilizadoresServices.Object);
        }


        [Test]
        public async Task CreateTestAsync()
        {
            var perfil_utilizador = await gateway.Create(
                new DataBase.Models.Perfil_Utilizador()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.Equals(perfil_utilizador.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var perfil_utilizador = await gateway.Update(
                1,
                new DataBase.Models.Perfil_Utilizador()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.Equals(perfil_utilizador.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var perfil_utilizador = await gateway.GetById(
                1,
                CancellationToken.None
            );

            Assert.Equals(perfil_utilizador.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var perfil_utilizador = await gateway.GetAll(
                CancellationToken.None
            );

            Assert.IsTrue(perfil_utilizador.Any(x => x.Nome == "Diogo Biscaia"));
        }

        [Test]
        public async Task DeleteAsync()
        {
            try
            {
                await gateway.Delete(
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
