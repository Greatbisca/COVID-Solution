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
    public class PermissoesTest
    {
        IPermissoesServices business;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Permissoes>> permissoesRepository = new Mock<IRepository<Permissoes>>();
            //Comportamento para criar o Doente
            permissoesRepository.Setup(x => x.CreateAsync(
                It.IsAny<Permissoes>(),
                CancellationToken.None
            )).ReturnsAsync(new Permissoes()
            {
                Id_Modulo = 1,
                Id_Perfil_Utilizador = 1,
                Criar = true,
                Eliminar = true,
                Escrever = true,
                Ler = true
            });

            permissoesRepository.Setup(x => x.UpdateAsync(
              It.IsAny<Permissoes>(),
              CancellationToken.None
          )).ReturnsAsync(new Permissoes()
          {
              Id_Modulo = 1,
              Id_Perfil_Utilizador = 1,
              Criar = true,
              Eliminar = true,
              Escrever = true,
              Ler = true
          });

            permissoesRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Permissoes()
            {
                Id_Modulo = 1,
                Id_Perfil_Utilizador = 1,
                Criar = true,
                Eliminar = true,
                Escrever = true,
                Ler = true
            });

            permissoesRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Permissoes>()
            {
                new Permissoes()
                {
                    Id_Modulo = 1,
                    Id_Perfil_Utilizador = 1,
                    Criar = true,
                    Eliminar = true,
                    Escrever = true,
                    Ler = true
                }
            });

            permissoesRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Permissoes>(),
                CancellationToken.None
            ));

            #endregion
            business = new PermissoesServices(permissoesRepository.Object);
        }
        [Test]
        public async Task CreateTestAsync()
        {
            var permissao = await business.CreateAsync(
                new Permissoes()
                {
                    Id = 1,
                    Id_Modulo = 1,
                    Id_Perfil_Utilizador = 1,
                    Ler = true,
                    Escrever = true,
                    Eliminar = true,
                    Criar = true
                },
                CancellationToken.None
            );

            Assert.AreEqual(permissao.Id_Perfil_Utilizador, 1);
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var permissao = await business.UpdateAsync(
                1,
                new Permissoes()
                {
                    Id = 1,
                    Id_Modulo = 1,
                    Id_Perfil_Utilizador = 1,
                    Ler = true,
                    Escrever = true,
                    Eliminar = true,
                    Criar = true
                },
                CancellationToken.None
            );

            Assert.AreEqual(permissao.Id_Perfil_Utilizador, 1);
        }

        [Test]
        public async Task GetTestAsync()
        {
            var permissao = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(permissao.Id_Perfil_Utilizador, 1);
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var permissao = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(permissao.Any(x => x.Id_Perfil_Utilizador == 1));
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
