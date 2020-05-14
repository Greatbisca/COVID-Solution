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
using Perfil_Utilizador = DataBase.Models.Perfil_Utilizador;

namespace BusinessTests
{
    public class PerfilUtilizadorTest
    {
        IPerfil_UtilizadoresServices business;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Perfil_Utilizador>> perfil_utilizadorRepository = new Mock<IRepository<Perfil_Utilizador>>();
            //Comportamento para criar o Perfil Utilizador
            perfil_utilizadorRepository.Setup(x => x.CreateAsync(
                It.IsAny<Perfil_Utilizador>(),
                CancellationToken.None
            )).ReturnsAsync(new Perfil_Utilizador()
            {
                Nome = "Diogo Biscaia"
            });

            perfil_utilizadorRepository.Setup(x => x.UpdateAsync(
              It.IsAny<Perfil_Utilizador>(),
              CancellationToken.None
          )).ReturnsAsync(new Perfil_Utilizador()
          {
              Nome = "Diogo Biscaia"
          });

            perfil_utilizadorRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Perfil_Utilizador()
            {
                Nome = "Diogo Biscaia"
            });

            perfil_utilizadorRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Perfil_Utilizador>()
            {
                new Perfil_Utilizador()
                {
                    Nome = "Diogo Biscaia"
                }
            });

            perfil_utilizadorRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Perfil_Utilizador>(),
                CancellationToken.None
            ));

            #endregion
            business = new Perfil_UtilizadorServices(perfil_utilizadorRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var perfil_utilziador = await business.CreateAsync(
                new Perfil_Utilizador()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.AreEqual(perfil_utilziador.Nome, "Diogo Biscaia");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var perfil_utilizador = await business.UpdateAsync(
                1,
                new Perfil_Utilizador()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.AreEqual(perfil_utilizador.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetTestAsync()
        {
            var perfil_utilizador = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(perfil_utilizador.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var perfil_utilizador = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(perfil_utilizador.Any(x => x.Nome == "Diogo Biscaia"));
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
