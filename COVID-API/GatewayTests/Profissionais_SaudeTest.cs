using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GatewayTests
{
    public class Profissionais_SaudeTest
    {
        IProfissionais_Saude gateway;


        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IProfissionais_SaudeServices> Profissionais_SaudeServices = new Mock<IProfissionais_SaudeServices>();
            //Comportamento para criar o Doente
            Profissionais_SaudeServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Profissionais_Saude>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Profissionais_Saude()
            {
                Nome = "Joaquim da Siva"
            });

            Profissionais_SaudeServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Profissionais_Saude>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Profissionais_Saude()
            {
                Nome = "Joaquim da Silva"
            });

            Profissionais_SaudeServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Profissionais_Saude()
            {
                Nome = "Joaquim da Silva"
            });

            Profissionais_SaudeServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Profissionais_Saude>()
            {
                new DataBase.ViewModels.Profissionais_Saude()
                {
                    Nome = "Joaquim da Silva"
                }
            });

            Profissionais_SaudeServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new Profissionais_SaudeController(Profissionais_SaudeServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var profissionais_saude = await gateway.Create(
                new DataBase.Models.Profissionais_Saude()
                {
                    Profissao = "Medico"
                },
                CancellationToken.None
            );

            Assert.Equals(profissionais_saude.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var profissionais_saude = await gateway.Update(
                1,
                new DataBase.Models.Profissionais_Saude()
                {
                    Profissao = "Medico"
                },
                CancellationToken.None
            );

            Assert.Equals(profissionais_saude.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var profissionais_saude = await gateway.GetById(
                1,
                CancellationToken.None
            );

            Assert.Equals(profissionais_saude.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var profissionais_saude = await gateway.GetAll(
                CancellationToken.None
            );

            Assert.IsTrue(profissionais_saude.Any(x => x.Nome == "Diogo Biscaia"));
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
