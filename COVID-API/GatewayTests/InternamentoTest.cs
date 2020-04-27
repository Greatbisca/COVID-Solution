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
    public class InternamentoTest
    {
        IInternamento gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IInternamentoServices> InternamentoServices = new Mock<IInternamentoServices>();
            //Comportamento para criar o Doente
            InternamentoServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Internamento>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Internamento()
            {
                Nome_Doente = "Diogo Biscaia"
            });

            InternamentoServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Internamento>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Internamento()
            {
                Nome_Doente= "Diogo Biscaia"
            });

            InternamentoServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Internamento()
            {
                Nome_Doente = "Diogo Biscaia"
            });

            InternamentoServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Internamento>()
            {
                new DataBase.ViewModels.Internamento()
                {
                    Nome_Doente = "Diogo Biscaia"
                }
            });

            InternamentoServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new InternamentoController(InternamentoServices.Object);
        }


        [Test]
        public async Task CreateTestAsync()
        {
            var internamento = await gateway.Create(
                new DataBase.Models.Internamento()
                {
                    Id_Doente = 12345
                },
                CancellationToken.None
            );

            Assert.Equals(internamento.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var internamento = await gateway.Update(
                1,
                new DataBase.Models.Internamento()
                {
                    Id_Doente = 12345
                },
                CancellationToken.None
            );

            Assert.Equals(internamento.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var internamento = await gateway.GetById(
                1,
                CancellationToken.None
            );

            Assert.Equals(internamento.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var internamento = await gateway.GetAll(
                CancellationToken.None
            );

            Assert.IsTrue(internamento.Any(x => x.Nome_Doente == "Diogo Biscaia"));
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
