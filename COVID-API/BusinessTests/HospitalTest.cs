using Business;
using Business.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using DataBase.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hospital = DataBase.Models.Hospital;

namespace BusinessTests
{
    public class HospitalTest
    {
        IHospitalServices business;

        [SetUp]
        public void Setup()
        {
            #region Mocks - comportamentos ficticios para a lógica de negócio
            Mock<IRepository<Hospital>> hospitalRepository = new Mock<IRepository<Hospital>>();
            //Comportamento para criar o Hospital
            hospitalRepository.Setup(x => x.CreateAsync(
                It.IsAny<Hospital>(),
                    CancellationToken.None
                )).ReturnsAsync(new Hospital()
                {
                    Nome = "S.Joao"
                });

            hospitalRepository.Setup(x => x.UpdateAsync(
                It.IsAny<Hospital>(),
                CancellationToken.None
            )).ReturnsAsync(new Hospital()
            {
                Nome = "S.Joao"
            });

            hospitalRepository.Setup(x => x.GetAsync(
                It.IsAny<int>(),
                CancellationToken.None
            )).ReturnsAsync(new Hospital()
            {
                Nome = "S.Joao"
            });

            hospitalRepository.Setup(x => x.GetAllAsync(
                CancellationToken.None
            )).ReturnsAsync(new List<Hospital>()
            {
                new Hospital()
                {
                    Nome = "S.Joao"
                }
            });

            hospitalRepository.Setup(x => x.DeleteAsync(
                It.IsAny<Hospital>(),
                CancellationToken.None
            ));
            #endregion
            business = new HospitalServices(hospitalRepository.Object);
        }

        [Test]
        public async Task CreateTestAsync()
        {
            var hospital = await business.CreateAsync(
                new Hospital()
                {
                    Nome = "S.Joao"
                },
                CancellationToken.None
            );

            Assert.AreEqual(hospital.Nome, "S.Joao");
        }


        [Test]
        public async Task UpdateTestAsync()
        {
            var hospital = await business.UpdateAsync(
                1,
                new Hospital()
                {
                    Nome = "S.Joao"
                },
                CancellationToken.None
            );

            Assert.AreEqual(hospital.Nome, "S.Joao");
        }

        [Test]
        public async Task GetTestAsync()
        {
            var hospital = await business.GetByIdAsync(
                1,
                CancellationToken.None
            );

            Assert.AreEqual(hospital.Nome, "S.Joao");
        }

        [Test]
        public async Task GetAllTestAsync()
        {
            var hospital = await business.GetAllAsync(
                CancellationToken.None
            );

            Assert.IsTrue(hospital.Any(x => x.Nome == "S.Joao"));
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
