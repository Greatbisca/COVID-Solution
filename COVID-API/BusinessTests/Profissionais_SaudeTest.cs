using Business;
using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using DataBase.RequestModel;
using DataBase.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Profissionais_Saude = DataBase.Models.Profissionais_Saude;

namespace BusinessTests
{
    public class Profissionais_SaudeTest
    {
        IProfissionais_SaudeServices business;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Profissionais_Saude>> profissionais_saudeRepository = new Mock<IRepository<Profissionais_Saude>>();
            Mock<IUtilizadoresServices> utilizadoresServices = new Mock<IUtilizadoresServices>();
            Mock<IPerfil_UtilizadoresServices> perfil_utilizadoresServices = new Mock<IPerfil_UtilizadoresServices>();
            //Comportamento para criar o Doente
            profissionais_saudeRepository.Setup(x => x.CreateAsync(
                It.IsAny<Profissionais_Saude>(),
                CancellationToken.None
            )).ReturnsAsync(new Profissionais_Saude()
            {
                Profissao = "Médico"
            });

            profissionais_saudeRepository.Setup(x => x.UpdateAsync(
              It.IsAny<Profissionais_Saude>(),
              CancellationToken.None
          )).ReturnsAsync(new Profissionais_Saude()
          {
              Profissao = "Médico"
          });

            profissionais_saudeRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Profissionais_Saude()
            {
                Profissao = "Médico"
            });

            profissionais_saudeRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Profissionais_Saude>()
            {
                new Profissionais_Saude()
                {
                    Profissao = "Médico"
                }
            });

            profissionais_saudeRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Profissionais_Saude>(),
                CancellationToken.None
            ));


            perfil_utilizadoresServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.Models.Perfil_Utilizador>()
            {
                new DataBase.Models.Perfil_Utilizador()
                {
                    Id = 1,
                    Nome = "Doente"
                }
            });

            utilizadoresServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Utilizadores()
            {
                Id = 1,
                CC = 1234,
                Idade = 20,
                Morada = "Porto",
                NIB = 1234,
                Nome = "Diogo Biscaia",
                Sexo = "M"
            });

            utilizadoresServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Utilizadores()
            {
                Id = 1,
                CC = 1234,
                Idade = 20,
                Morada = "Porto",
                NIB = 1234,
                Nome = "Diogo Biscaia",
                Sexo = "M"
            });

            utilizadoresServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Utilizadores()
            {
                Id = 1,
                CC = 1234,
                Idade = 20,
                Morada = "Porto",
                NIB = 1234,
                Nome = "Diogo Biscaia",
                Sexo = "M"
            });

            #endregion
            business = new Profissionais_SaudeServices(profissionais_saudeRepository.Object, utilizadoresServices.Object, perfil_utilizadoresServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var profissionais_saude = await business.CreateAsync(
                new ProfissionalSaudeRequest()
                {
                    CC = 12345,
                    Idade = 20,
                    Id_Hospital = 1,
                    Morada = "Porto",
                    NIB = 12345,
                    Nome = "Diogo Biscaia",
                    Sexo = "M",
                    Profissao = "Médico"
                },
                CancellationToken.None
            );

            Assert.AreEqual(profissionais_saude.Profissao, "Médico");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var profissionais_saude = await business.UpdateAsync(
                1,
                new ProfissionalSaudeRequest()
                {
                    CC = 12345,
                    Idade = 20,
                    Id_Hospital = 1,
                    Morada = "Porto",
                    NIB = 12345,
                    Nome = "Diogo Biscaia",
                    Sexo = "M",
                    Profissao = "Médico"
                },
                CancellationToken.None
            );

            Assert.AreEqual(profissionais_saude.Profissao, "Médico");
        }

        [Test]
        public async Task GetTestAsync()
        {
            var profissionais_saude = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(profissionais_saude.Profissao, "Médico");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var profissionais_saude = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(profissionais_saude.Any(x => x.Profissao == "Médico"));
        }

        [Test]
        public async Task DeleteTestAsync()
        {
            try
            {
                await business.DeleteAsync(
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
