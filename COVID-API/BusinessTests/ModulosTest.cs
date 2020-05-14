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
    public class ModulosTest
    {
        IModulosServices business;


        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Modulos>> modulosRepository = new Mock<IRepository<Modulos>>();
            //Comportamento para criar o Modulo
            modulosRepository.Setup(x => x.CreateAsync(
                It.IsAny<Modulos>(),
                CancellationToken.None
            )).ReturnsAsync(new Modulos()
            {
                Nome = "Diogo Biscaia"
            });

            modulosRepository.Setup(x => x.UpdateAsync(
              It.IsAny<Modulos>(),
              CancellationToken.None
          )).ReturnsAsync(new Modulos()
          {
              Nome = "Diogo Biscaia"
          });

            modulosRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Modulos()
            {
                Nome = "Diogo Biscaia"
            });

            modulosRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Modulos>()
            {
                new Modulos()
                {
                    Nome = "Diogo Biscaia"
                }
            });

            modulosRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Modulos>(),
                CancellationToken.None
            ));

            #endregion
            business = new ModulosServices(modulosRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var modulos = await business.CreateAsync(
                new Modulos()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.AreEqual(modulos.Nome, "Diogo Biscaia");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var modulos = await business.UpdateAsync(
                1,
                new Modulos()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.AreEqual(modulos.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetTestAsync()
        {
            var modulos = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(modulos.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var modulos = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(modulos.Any(x => x.Nome == "Diogo Biscaia"));
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
