using Business;
using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using DataBase.RequestModel;
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
            Mock<IUtilizadoresServices> utilizadoresServices = new Mock<IUtilizadoresServices>();
            Mock<IPerfil_UtilizadoresServices> perfil_utilizadoresServices = new Mock<IPerfil_UtilizadoresServices>();
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

            perfil_utilizadoresServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Perfil_Utilizador>()
            {
                new Perfil_Utilizador()
                {
                    Id = 1,
                    Nome = "Doente"
                }
            });

            utilizadoresServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Utilizadores()
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
                It.IsAny<Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new Utilizadores()
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
                It.IsAny<Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new Utilizadores()
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

            business = new DoenteServices(doenteRepository.Object, utilizadoresServices.Object, perfil_utilizadoresServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var doente = await business.CreateAsync(
                new DoenteRequest()
                {
                    Regiao = "Porto",
                    CC = 1234,
                    Idade = 20,
                    Morada = "Porto",
                    NIB = 1234,
                    Nome = "Diogo Biscaia",
                    Sexo = "M"
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
                new DoenteRequest()
                {
                    Regiao = "Porto",
                    CC = 1234,
                    Idade = 20,
                    Morada = "Porto",
                    NIB = 1234,
                    Nome = "Diogo Biscaia",
                    Sexo = "M"
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
