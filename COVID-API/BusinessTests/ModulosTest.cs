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
            Mock<IPermissoesServices> permissoesServices = new Mock<IPermissoesServices>();
            Mock<IRepository<Perfil_Utilizador>> perfil_utilizadorRepository = new Mock<IRepository<Perfil_Utilizador>>();
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

            permissoesServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));

            permissoesServices.Setup(x => x.CreateAsync(
                It.IsAny<Permissoes>(),
                CancellationToken.None
            )).ReturnsAsync(new Permissoes()
            {
                Id = 1,
                Criar = true,
                Eliminar = true,
                Escrever = true,
                Id_Modulo = 1,
                Id_Perfil_Utilizador = 1,
                Ler = true
            });

            permissoesServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Permissoes>()
            {
                new Permissoes()
                {
                    Id = 1,
                    Criar = true,
                    Eliminar = true,
                    Escrever = true,
                    Id_Modulo = 1,
                    Id_Perfil_Utilizador = 1,
                    Ler = true
                }
            });

            perfil_utilizadorRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Perfil_Utilizador>()
            {
                new Perfil_Utilizador()
                {
                    Id = 1,
                    Nome = "Médico"
                }
            });

            #endregion
            business = new ModulosServices(modulosRepository.Object, permissoesServices.Object, perfil_utilizadorRepository.Object);
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
