using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GatewayTests
{
    public class PermissoesTest
    {
        IPermissoes gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IPermissoesServices> PermissoesServices = new Mock<IPermissoesServices>();
            //Comportamento para criar Premissoes
            PermissoesServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Permissoes>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Permissoes()
            {
                Id = 1
            });

            PermissoesServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Permissoes>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Permissoes()
            {
                Id = 1
            });

            PermissoesServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Permissoes()
            {
                Id = 1
            });

            PermissoesServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Permissoes>()
            {
                new DataBase.ViewModels.Permissoes()
                {
                    Id = 1
                }
            });

            PermissoesServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new PermissoesController(PermissoesServices.Object);
        }
    }
}
