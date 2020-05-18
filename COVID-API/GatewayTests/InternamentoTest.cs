using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
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
    public class InternamentoTest
    {
        IInternamento gateway;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IInternamentoServices> InternamentoServices = new Mock<IInternamentoServices>();
            Mock<IDoenteServices> DoenteServices = new Mock<IDoenteServices>();
            Mock<IHospitalServices> HospitalServices = new Mock<IHospitalServices>();
            Mock<IUtilizadoresServices> UtilizadoresServices = new Mock<IUtilizadoresServices>();
            //Comportamento para criar o Doente
            InternamentoServices.Setup(x => x.CreateAsync(
                It.IsAny<DataBase.Models.Internamento>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Internamento()
            {
                Id_Doente = 1
            });

            InternamentoServices.Setup(x => x.UpdateAsync(
                It.IsAny<int>(),
                It.IsAny<DataBase.Models.Internamento>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Internamento()
            {
                Id_Doente = 1
            });

            InternamentoServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Internamento()
            {
                Id_Doente = 1
            });

            InternamentoServices.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<DataBase.Models.Internamento>()
            {
                new DataBase.Models.Internamento()
                {
                    Id_Doente = 1
                }
            });

            InternamentoServices.Setup(x => x.DeleteAsync(
                It.IsAny<int>(),
                CancellationToken.None
            ));

            DoenteServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Doente()
            {
                Id = 1,
                Regiao = "Porto",
                Id_Utilizador = 1
            });

            HospitalServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Hospital()
            {
                Id = 1,
                Nome = "S. João",
                Distrito = "Porto"
            });

            UtilizadoresServices.Setup(x => x.GetByIdAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new DataBase.Models.Utilizadores()
            {
                Id = 1,
                Nome = "Diogo Biscaia"
            });

            #endregion
            gateway = new InternamentoController(
                InternamentoServices.Object, 
                DoenteServices.Object, 
                HospitalServices.Object,
                UtilizadoresServices.Object
            );
        }


        [Test]
        public async Task CreateTestAsync()
        {
            var internamento = await gateway.CreateAsync(
                new DataBase.Models.Internamento()
                {
                    Id_Doente = 12345
                },
                CancellationToken.None
            );

            Assert.AreEqual(internamento.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task UpdateTestAsync()
        {
            var internamento = await gateway.UpdateAsync(
                1,
                new DataBase.Models.Internamento()
                {
                    Id_Doente = 12345
                },
                CancellationToken.None
            );

            Assert.AreEqual(internamento.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task GetByIdTestAsync()
        {
            var internamento = await gateway.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(internamento.Nome_Doente, "Diogo Biscaia");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var internamento = await gateway.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(internamento.Any(x => x.Nome_Doente == "Diogo Biscaia"));
        }

        [Test]
        public async Task DeleteTestAsync()
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
