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
            Mock<IUtilizadoresServices> UtilizadoresServices = new Mock<IUtilizadoresServices>();
            //Comportamento para criar o Doente
            Profissionais_SaudeServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Profissionais_Saude>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Profissionais_Saude()
            {
                Id = 1, 
                Id_Hospital = 1,
                Id_Utilizador = 1,
                Profissao = "Médico"
            });

            Profissionais_SaudeServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Profissionais_Saude>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Profissionais_Saude()
            {
                Id = 1,
                Id_Hospital = 1,
                Id_Utilizador = 1,
                Profissao = "Médico"
            });

            Profissionais_SaudeServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Profissionais_Saude()
            {
                Id = 1,
                Id_Hospital = 1,
                Id_Utilizador = 1,
                Profissao = "Médico"
            }); 

            Profissionais_SaudeServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.Models.Profissionais_Saude>()
            {
                new DataBase.Models.Profissionais_Saude()
                {
                    Id = 1,
                    Id_Hospital = 1,
                    Id_Utilizador = 1,
                    Profissao = "Médico"
                }
            });

            Profissionais_SaudeServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));

            UtilizadoresServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Utilizadores()
            {
                Id = 1,
                CC = 123456,
                Idade = 23,
                Id_Perfil_Utilizador = 1,
                Morada = "Senhora da Hora",
                NIB = 12345,
                Nome = "Diogo Biscaia",
                Sexo = "M",
                Username = "GreatBisca"
            });
            #endregion
            gateway = new Profissionais_SaudeController(Profissionais_SaudeServices.Object, UtilizadoresServices.Object);
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

            Assert.AreEqual(profissionais_saude.Nome, "Diogo Biscaia");
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

            Assert.AreEqual(profissionais_saude.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var profissionais_saude = await gateway.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(profissionais_saude.Nome, "Diogo Biscaia");
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
