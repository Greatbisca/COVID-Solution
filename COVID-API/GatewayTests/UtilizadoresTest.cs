using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using DataBase.Models;
using DataBase.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    public class UtilizadoresTest
    {
        IUtilizadores gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IUtilizadoresServices> UtilizadoresServices = new Mock<IUtilizadoresServices>();
            //Comportamento para criar o Utilizador
            UtilizadoresServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Utilizadores()
            {
                Username = "Greatbisca"

            });

            UtilizadoresServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Utilizadores>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Utilizadores()
            {
                Username = "Greatbisca"
            });

            UtilizadoresServices.Setup(x => x.GetByIdAsync(
              It.IsAny<int>(),
              CancellationToken.None
          )).ReturnsAsync(new DataBase.ViewModels.Utilizadores()
          {
              Username = "Greatbisca"
          });

            UtilizadoresServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Utilizadores>()
            {
                new DataBase.ViewModels.Utilizadores()
                {
                    Username = "Greatbisca"
                }
            });

            UtilizadoresServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new UtilizadoresController(UtilizadoresServices.Object);
        }

            [Test]
        public async Task CreateTestAsync()
        {
            var utilizadores = await gateway.Create(
                new DataBase.Models.Utilizadores()
                {
                    Username = "Greatbisca"
                },
                CancellationToken.None
            );

            Assert.Equals(utilizadores.Username, "Greatbisca");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var utilizadores = await gateway.Update(
                1,
                new DataBase.Models.Utilizadores()
                {
                    Nome = "Greatbisca"
                },
                CancellationToken.None
            );

            Assert.Equals(utilizadores.Username, "Greatbisca");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var utilizadores = await gateway.GetById(
                1,
                CancellationToken.None
            );

            Assert.Equals(utilizadores.Username, "Greatbisca");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var utilizadores = await gateway.GetAll(
                CancellationToken.None
            );

            Assert.IsTrue(utilizadores.Any(x => x.Username == "Greatbisca"));
        }

        [Test]
        public async Task DeleteAsync()
        {
            try
            {
                await gateway.Delete(
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
