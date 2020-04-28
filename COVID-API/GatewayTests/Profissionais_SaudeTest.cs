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
            var profissionais_saude = await gateway.CreateAsync(
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
            var profissionais_saude = await gateway.UpdateAsync(
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
            var profissionais_saude = await gateway.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.Equals(profissionais_saude.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var profissionais_saude = await gateway.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(profissionais_saude.Any(x => x.Nome == "Diogo Biscaia"));
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
