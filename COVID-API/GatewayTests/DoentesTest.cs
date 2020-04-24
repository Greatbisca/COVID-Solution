using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    public class DoentesTest
    {
        IDoente gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IDoenteServices> DoenteServices = new Mock<IDoenteServices>();
            //Comportamento para criar o Doente
            DoenteServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Doente>(), 
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Doente()
            {
                Nome = "Diogo Biscaia"
            });

            DoenteServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Doente>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Doente()
            {
                Nome = "Diogo Biscaia"
            });

            DoenteServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Doente()
            {
                Nome = "Diogo Biscaia"
            });

            DoenteServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Doente>()
            {
                new DataBase.ViewModels.Doente()
                {
                    Nome = "Diogo Biscaia"
                }
            });

            DoenteServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new DoenteController(DoenteServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var doente = await gateway.Create(
                new DataBase.Models.Doente()
                {
                    Nome = "Diogo Biscaia"
                }, 
                CancellationToken.None
            );

            Assert.Equals(doente.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var doente = await gateway.Update(
                1,
                new DataBase.Models.Doente()
                {
                    Nome = "Diogo Biscaia"
                }, 
                CancellationToken.None
            );

            Assert.Equals(doente.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var doente = await gateway.GetById(
                1,
                CancellationToken.None
            );

            Assert.Equals(doente.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var doentes = await gateway.GetAll(
                CancellationToken.None
            );

            Assert.IsTrue(doentes.Any(x => x.Nome == "Diogo Biscaia"));
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