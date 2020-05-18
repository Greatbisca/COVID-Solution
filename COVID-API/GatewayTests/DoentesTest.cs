using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GatewayTests
{
    public class DoentesTest
    {
        IDoente gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IDoenteServices> DoenteServices = new Mock<IDoenteServices>();
            Mock<IUtilizadoresServices> UtilizadoresServices = new Mock<IUtilizadoresServices>();
            //Comportamento para criar o Doente
            DoenteServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Doente>(), 
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Doente()
            {
                Id = 1,
                Id_Utilizador = 1,
                Regiao = "Porto"
            });

            DoenteServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Doente>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Doente()
            {
                Id = 1,
                Id_Utilizador = 1,
                Regiao = "Porto"
            });

            DoenteServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Doente()
            {
                Id = 1,
                Id_Utilizador = 1,
                Regiao = "Porto"
            });

            DoenteServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.Models.Doente>()
            {
                new DataBase.Models.Doente()
                {
                    Id = 1,
                Id_Utilizador = 1,
                Regiao = "Porto"
                }
            });

            DoenteServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));

            UtilizadoresServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Utilizadores()
            {
                Id = 1,
                Nome = "Diogo Biscaia"
            });
            #endregion
            gateway = new DoenteController(DoenteServices.Object, UtilizadoresServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var doente = await gateway.CreateAsync(
                new DataBase.Models.Doente()
                {
                    Id = 1,
                    Id_Utilizador = 1,
                    Regiao = "Porto"
                }, 
                CancellationToken.None
            );

            Assert.AreEqual(doente.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var doente = await gateway.UpdateAsync(
                1,
                new DataBase.Models.Doente()
                {
                    Id = 1,
                    Id_Utilizador = 1,
                    Regiao = "Porto"
                }, 
                CancellationToken.None
            );

            Assert.AreEqual(doente.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var doente = await gateway.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(doente.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var doentes = await gateway.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(doentes.Any(x => x.Nome == "Diogo Biscaia"));
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
            } catch
            {
                Assert.IsTrue(false);
            } finally
            {
                Assert.IsTrue(true);
            }
        }
    }
}