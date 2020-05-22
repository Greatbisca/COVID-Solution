using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class HospitalRepository : IRepository<Hospital>
    {
        public async Task<Hospital> CreateAsync(Hospital entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var hospital = ctx.Hospital.Add(new DataModels.Hospital()
                    {
                        Distrito = entity.Distrito,
                        Nome = entity.Nome
                    });

                    ctx.SaveChanges();

                    return new Hospital()
                    {
                        Id = hospital.Entity.IdHospital,
                        Distrito = hospital.Entity.Distrito,
                        Nome = hospital.Entity.Nome
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Hospital entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var hospital = ctx.Hospital.Find(entity.Id);
                    ctx.Hospital.Remove(hospital);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Hospital>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.Hospital.Select(x => new Hospital()
                    {
                        Id = x.IdHospital,
                        Nome = x.Nome,
                        Distrito = x.Distrito
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Hospital> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var hospital = ctx.Hospital.Find(id);

                    return new Hospital()
                    {
                        Id = hospital.IdHospital,
                        Nome = hospital.Nome,
                        Distrito = hospital.Distrito
                    };
                }
            }, ct);
        }

        public async Task<Hospital> UpdateAsync(Hospital entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var hospital = ctx.Hospital.Find(entity.Id);
                    hospital.Nome = entity.Nome;
                    hospital.Distrito = entity.Distrito;

                    ctx.Hospital.Update(hospital);
                    ctx.SaveChanges();

                    return new Hospital()
                    {
                        Id = hospital.IdHospital,
                        Nome = hospital.Nome,
                        Distrito = hospital.Distrito
                    };
                }
            },
            ct);
        }
    }
}
