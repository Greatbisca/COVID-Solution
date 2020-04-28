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

namespace GatewayTests
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
            UtilizadoresServices.Setup(x => x.ValidateLoginAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                CancellationToken.None
            )).ReturnsAsync("AUTHENTICATION_TOKEN");
            
            #endregion
            gateway = new UtilizadoresController(UtilizadoresServices.Object);
        }

        [Test]
        public async Task LoginTestAsync()
        {
            var token = await gateway.LoginAsync(
                new LoginRequestModel()
                {
                    Password = "Diogo",
                    Username = "Biscaia"
                },
                CancellationToken.None
            );

            Assert.Equals(token, "AUTHENTICATION_TOKEN");
        }
    }
}
