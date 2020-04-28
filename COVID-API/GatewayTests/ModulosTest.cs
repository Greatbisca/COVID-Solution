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
    public class ModulosTest
    {
        IModulos gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IModulosServices> ModulosServices = new Mock<IModulosServices>();
            //Comportamento para criar o Doente
            ModulosServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Modulos>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Modulos()
            {
                Nome = "Diogo Biscaia"
            });

            ModulosServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Modulos>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Modulos()
            {
                Nome = "Diogo Biscaia"
            });

            ModulosServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Modulos()
            {
                Nome = "Diogo Biscaia"
            });

            ModulosServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Modulos>()
            {
                new DataBase.ViewModels.Modulos()
                {
                    Nome = "Diogo Biscaia"
                }
            });

            ModulosServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new ModulosController(ModulosServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var modulos = await gateway.CreateAsync(
                new DataBase.Models.Modulos()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.Equals(modulos.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var modulos = await gateway.UpdateAsync(
                1,
                new DataBase.Models.Modulos()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.Equals(modulos.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var modulos = await gateway.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.Equals(modulos.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var modulos = await gateway.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(modulos.Any(x => x.Nome == "Diogo Biscaia"));
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
