using Business;
using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessTests
{
    public class UtilizadoresTest
    {
        IUtilizadoresServices business;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Utilizadores>> utilizadorRepository = new Mock<IRepository<Utilizadores>>();

            utilizadorRepository.Setup(x => x.CreateAsync(
                It.IsAny<Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new Utilizadores()
            {
                CC = 12345,
                Id = 1,
                Idade = 20,
                Id_Perfil_Utilizador = 1,
                Morada = "Porto",
                NIB = 12345,
                Nome = "Diogo Biscaia",
                Sexo = "M",
                Username = "12345"
            });

            utilizadorRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Utilizadores>(),
                CancellationToken.None
            ));

            utilizadorRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Utilizadores>()
            {
                new Utilizadores()
                {
                    CC = 12345,
                    Id = 1,
                    Idade = 20,
                    Id_Perfil_Utilizador = 1,
                    Morada = "Porto",
                    NIB = 12345,
                    Nome = "Diogo Biscaia",
                    Sexo = "M",
                    Username = "12345"
                }
            });

            utilizadorRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Utilizadores()
            {
                CC = 12345,
                Id = 1,
                Idade = 20,
                Id_Perfil_Utilizador = 1,
                Morada = "Porto",
                NIB = 12345,
                Nome = "Diogo Biscaia",
                Sexo = "M",
                Username = "12345"
            });

            utilizadorRepository.Setup(x => x.UpdateAsync(
                It.IsAny<Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new Utilizadores()
            {
                CC = 12345,
                Id = 1,
                Idade = 20,
                Id_Perfil_Utilizador = 1,
                Morada = "Porto",
                NIB = 12345,
                Nome = "Diogo Biscaia",
                Sexo = "M",
                Username = "12345"
            });
            #endregion

            business = new UtilizadoresServices(utilizadorRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var teste = await business.CreateAsync(
                new Utilizadores()
                {
                    CC = 12345,
                    Id = 1,
                    Idade = 20,
                    Id_Perfil_Utilizador = 1,
                    Morada = "Porto",
                    NIB = 12345,
                    Nome = "Diogo Biscaia",
                    Sexo = "M",
                    Username = "12345"
                },
                CancellationToken.None
            );

            Assert.AreEqual(teste.Nome, "Diogo Biscaia");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var teste = await business.UpdateAsync(
                1,
                new Utilizadores()
                {
                    CC = 12345,
                    Id = 1,
                    Idade = 20,
                    Id_Perfil_Utilizador = 1,
                    Morada = "Porto",
                    NIB = 12345,
                    Nome = "Diogo Biscaia",
                    Sexo = "M",
                    Username = "12345"
                },
                CancellationToken.None
            );

            Assert.AreEqual(teste.Nome, "Diogo Biscaia");
        }

        [Test]
        public async Task GetTestAsync()
        {
            var teste = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(teste.Nome, "Diogo Biscaia");
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

        [Test]
        public async Task ValidateLoginTestAsync()
        {
            try
            {
                await business.ValidateLoginAsync(
                    "12345",
                    "",
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
