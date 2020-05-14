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
    public class InternamentoTest
    {
        IInternamentoServices business;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Internamento>> internamentoRepository = new Mock<IRepository<Internamento>>();
            //Comportamento para criar o Doente
            internamentoRepository.Setup(x => x.CreateAsync(
                It.IsAny<Internamento>(),
                CancellationToken.None
            )).ReturnsAsync(new Internamento()
            {
                Id_Doente = 12345
            });

            internamentoRepository.Setup(x => x.UpdateAsync(
              It.IsAny<Internamento>(),
              CancellationToken.None
          )).ReturnsAsync(new Internamento()
          {
               Id_Doente = 12345
          });

            internamentoRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Internamento()
            {
                Id_Doente = 12345
            });

            internamentoRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Internamento>()
            {
                new Internamento()
                {
                  Id_Doente = 12345
                }
            });

            internamentoRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Internamento>(),
                CancellationToken.None
            ));

            #endregion
            business = new InternamentoServices(internamentoRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var internamento = await business.CreateAsync(
                new Internamento()
                {
                    Id_Doente = 12345
                },
                CancellationToken.None
            );

            Assert.AreEqual(internamento.Nome_Doente, "Diogo Biscaia");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var internanemto = await business.UpdateAsync(
                1,
                new Internamento()
                {
                    Id_Doente = 12345
                },
                CancellationToken.None
            );

            Assert.AreEqual(internanemto.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task GetTestAsync()
        {
            var internamento = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(internamento.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var doentes = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(doentes.Any(x => x.Nome_Doente == "Diogo Biscaia"));
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
