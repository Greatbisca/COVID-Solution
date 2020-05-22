using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class InternamentoRepository : IRepository<Internamento>
    {
        public async Task<Internamento> CreateAsync(Internamento entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var internamento = ctx.Internamento.Add(new DataModels.Internamento()
                    {
                        DataAlta = entity.Data_Alta.DateTime,
                        DataInternamento = entity.Data_Internamento.DateTime,
                        IdDoente = entity.Id_Doente,
                        IdHospital = entity.Id_Hospital
                    });

                    ctx.SaveChanges();

                    return new Internamento()
                    {
                        Id = internamento.Entity.IdInternamento,
                        Data_Alta = internamento.Entity.DataAlta,
                        Data_Internamento = internamento.Entity.DataInternamento,
                        Id_Doente = internamento.Entity.IdDoente,
                        Id_Hospital = internamento.Entity.IdHospital
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Internamento entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var internamento = ctx.Internamento.Find(entity.Id);
                    ctx.Internamento.Remove(internamento);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Internamento>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.Internamento.Select(x => new Internamento()
                    {
                        Id = x.IdInternamento,
                        Data_Alta = x.DataAlta,
                        Data_Internamento = x.DataInternamento,
                        Id_Doente = x.IdDoente,
                        Id_Hospital = x.IdHospital
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Internamento> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var internamento = ctx.Internamento.Find(id);

                    return new Internamento()
                    {
                        Id = internamento.IdInternamento,
                        Data_Alta = internamento.DataAlta,
                        Data_Internamento = internamento.DataInternamento,
                        Id_Doente = internamento.IdDoente,
                        Id_Hospital = internamento.IdHospital
                    };
                }
            }, ct);
        }

        public async Task<Internamento> UpdateAsync(Internamento entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var internamento = ctx.Internamento.Find(entity.Id);
                    internamento.DataAlta = entity.Data_Alta.DateTime;
                    internamento.DataInternamento = entity.Data_Internamento.DateTime;
                    internamento.IdDoente = entity.Id_Doente;
                    internamento.IdHospital = entity.Id_Hospital;

                    ctx.Internamento.Update(internamento);
                    ctx.SaveChanges();

                    return new Internamento()
                    {
                        Id = internamento.IdInternamento,
                        Data_Alta = internamento.DataAlta,
                        Data_Internamento = internamento.DataInternamento,
                        Id_Doente = internamento.IdDoente,
                        Id_Hospital = internamento.IdHospital
                    };
                }
            },
            ct);
        }
    }
}
