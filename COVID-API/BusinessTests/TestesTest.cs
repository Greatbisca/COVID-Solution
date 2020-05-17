using Business;
using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessTests
{
    public class TestesTest
    {
        ITesteServices business;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Teste>> testeRepository = new Mock<IRepository<Teste>>();
            //Comportamento para criar o Doente
            testeRepository.Setup(x => x.CreateAsync(
                It.IsAny<Teste>(),
                CancellationToken.None
            )).ReturnsAsync(new Teste()
            {
                Resultado_Teste = "Positivo"
            });

            testeRepository.Setup(x => x.UpdateAsync(
              It.IsAny<Teste>(),
              CancellationToken.None
          )).ReturnsAsync(new Teste()
          {
              Resultado_Teste = "Positivo"
          });

            testeRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Teste()
            {
                Resultado_Teste = "Positivo"
            });

            testeRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Teste>()
            {
                new Teste()
                {
                   Resultado_Teste = "Positivo"
                }
            });

            testeRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Teste>(),
                CancellationToken.None
            ));

            #endregion
            business = new TesteServices(testeRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var teste = await business.CreateAsync(
                new Teste()
                {
                    Tipo_Teste = "Teste COVID"
                },
                CancellationToken.None
            );

            Assert.AreEqual(teste.Resultado_Teste, "Positivo");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var teste = await business.UpdateAsync(
                1,
                new Teste()
                {
                    Tipo_Teste = "Teste COVID"
                },
                CancellationToken.None
            );

            Assert.AreEqual(teste.Resultado_Teste, "Positivo");
        }

        [Test]
        public async Task GetTestAsync()
        {
            var teste = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(teste.Resultado_Teste, "Positivo");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var teste = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(teste.Any(x => x.Resultado_Teste == "Positivo"));
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
