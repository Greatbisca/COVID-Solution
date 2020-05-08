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
    public class TestesTest
    {
        ITestes gateway;


        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<ITesteServices> TesteServices = new Mock<ITesteServices>();
            //Comportamento para criar o Teste
            TesteServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Teste>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Teste()
            {
                Resultado_Teste = "Positivo"
            });

            TesteServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Teste>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Teste()
            {
                Resultado_Teste = "Positivo"
            });

            TesteServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Teste()
            {
                Resultado_Teste = "Positivo"
            });

            TesteServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Teste>()
            {
                new DataBase.ViewModels.Teste()
                {
                    Resultado_Teste = "Positivo"
                }
            });

            TesteServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new TesteController(TesteServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var teste = await gateway.CreateAsync(
                new DataBase.Models.Teste()
                {
                    Tipo_Teste = "Teste COVID"
                },
                CancellationToken.None
            );

            Assert.AreEqual(teste.Tipo_Teste, "Teste COVID");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var teste = await gateway.UpdateAsync(
                1,
                new DataBase.Models.Teste()
                {
                    Tipo_Teste = "Teste COVID"
                },
                CancellationToken.None
            );

            Assert.AreEqual(teste.Tipo_Teste, "Teste COVID");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var teste = await gateway.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(teste.Tipo_Teste, "Teste COVID");

        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var teste = await gateway.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(teste.Any(x => x.Tipo_Teste == "Teste COVID"));
        }

        [Test]
        public async Task DeleteAsync()
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
