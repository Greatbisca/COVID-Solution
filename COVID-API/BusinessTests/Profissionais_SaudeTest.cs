using Business;
using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
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

            #endregion
            business = new Profissionais_SaudeServices(profissionais_saudeRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var profissionais_saude = await business.CreateAsync(
                new Profissionais_Saude()
                {
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
                new Profissionais_Saude()
                {
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
