using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class ModulosRepository : IRepository<Modulos>
    {
        public async Task<Modulos> CreateAsync(Modulos entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var modulo = ctx.Modulos.Add(new DataModels.Modulos()
                    {
                        Endpoint = entity.EndPoint,
                        Nome = entity.Nome
                    });

                    ctx.SaveChanges();

                    return new Modulos()
                    {
                        Id = modulo.Entity.IdModulos,
                        Nome = modulo.Entity.Nome,
                        EndPoint = modulo.Entity.Endpoint
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Modulos entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var modulo = ctx.Modulos.Find(entity.Id);
                    ctx.Modulos.Remove(modulo);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Modulos>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.Modulos.Select(x => new Modulos()
                    {
                        Id = x.IdModulos,
                        EndPoint = x.Endpoint,
                        Nome = x.Nome
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Modulos> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var modulo = ctx.Modulos.Find(id);

                    return new Modulos()
                    {
                        Id = modulo.IdModulos,
                        EndPoint = modulo.Endpoint,
                        Nome = modulo.Nome
                    };
                }
            }, ct);
        }

        public async Task<Modulos> UpdateAsync(Modulos entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var modulo = ctx.Modulos.Find(entity.Id);

                    modulo.IdModulos = entity.Id;
                    modulo.Endpoint = entity.EndPoint;
                    modulo.Nome = entity.Nome;

                    ctx.Modulos.Update(modulo);
                    ctx.SaveChanges();

                    return new Modulos()
                    {
                        Id = modulo.IdModulos,
                        EndPoint = modulo.Endpoint,
                        Nome = modulo.Nome
                    };
                }
            },
            ct);
        }
    }
}
