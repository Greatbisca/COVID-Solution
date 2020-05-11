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
                Nome = "Diogo Biscaia"
            });

            #endregion
            business = new DoenteServices(doenteRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var doente = await business.CreateAsync(
                new Doente()
                {
                    Nome = "Diogo Biscaia"
                },
                CancellationToken.None
            );

            Assert.AreEqual(doente.Nome, "Diogo Biscaia");
        }
    }
}
