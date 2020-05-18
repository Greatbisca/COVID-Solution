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
    public class DoenteTest
    {
        IDoenteServices business;


        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Doente>> doenteRepository = new Mock<IRepository<Doente>>();
            //Comportamento para criar o Doente
            doenteRepository.Setup(x => x.CreateAsync(
                It.IsAny<Doente>(),
                CancellationToken.None
            )).ReturnsAsync(new Doente()
            {
                Id_Utilizador = 1,
                Id = 1,
                Regiao = "Porto"
            });

            doenteRepository.Setup(x => x.UpdateAsync(
              It.IsAny<Doente>(),
              CancellationToken.None
          )).ReturnsAsync(new Doente()
          {
              Id_Utilizador = 1,
              Id = 1,
              Regiao = "Porto"
          });

            doenteRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Doente()
            {
                Id_Utilizador = 1,
                Id = 1,
                Regiao = "Porto"
            });

            doenteRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Doente>()
            {
                new Doente()
                {
                    Id_Utilizador = 1,
                Id = 1,
                Regiao = "Porto"
                }
            });

            doenteRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Doente>(),
                CancellationToken.None
            ));

        #endregion
        business = new DoenteServices(doenteRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var doente = await business.CreateAsync(
                new Doente()
                {
                    Id_Utilizador = 1,
                    Id = 1,
                    Regiao = "Porto"
                },
                CancellationToken.None
            );

            Assert.AreEqual(doente.Id, 1);
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var doente = await business.UpdateAsync(
                1,
                new Doente()
                {
                    Id_Utilizador = 1,
                    Id = 1,
                    Regiao = "Porto"
                },
                CancellationToken.None
            );

            Assert.AreEqual(doente.Id, 1);
        }

        [Test]
        public async Task GetTestAsync()
        {
            var doente = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(doente.Id, 1);
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var doentes = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(doentes.Any(x => x.Id == 1));
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
