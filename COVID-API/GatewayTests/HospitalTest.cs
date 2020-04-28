using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class HospitalTest
    {
        IHospital gateway;

        [SetUp]

        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IHospitalServices> HospitalServices = new Mock<IHospitalServices>();
            //Comportamento para criar o Hospital
            HospitalServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Hospital>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Hospital()
            {
                Nome = "S.Joao"
            });

            HospitalServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Hospital>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Hospital()
            {
                Nome = "S.Joao"
            });

            HospitalServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.ViewModels.Hospital()
            {
                Nome = "S.Joao"
            });

            HospitalServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.ViewModels.Hospital>()
            {
                new DataBase.ViewModels.Hospital()
                {
                    Nome = "S.Joao"
                }
            });

            HospitalServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));
            #endregion
            gateway = new HospitalController(HospitalServices.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var hospital = await gateway.CreateAsync(
                new DataBase.Models.Hospital()
                {
                    Nome = "S.Joao"
                },
                CancellationToken.None
            );

            Assert.Equals(hospital.Nome, "S.Joao");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var hospital = await gateway.UpdateAsync(
                1,
                new DataBase.Models.Hospital()
                {
                    Nome = "S.Joao"
                },
                CancellationToken.None
            );

            Assert.Equals(hospital.Nome, "S.Joao");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var hospital = await gateway.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.Equals(hospital.Nome, "S.Joao");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var hospital = await gateway.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(hospital.Any(x => x.Nome == "S.Joao"));
        }

        [Test]
        public async Task DeleteAsync()
        {
            try
            {
                await gateway.DeleteAsync(
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
