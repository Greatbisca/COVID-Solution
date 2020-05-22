using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class DoentesRepository : IRepository<Doente>
    {
        public async Task<Doente> CreateAsync(Doente entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var doente = ctx.Doente.Add(new DataModels.Doente()
                    {
                        IdUtilizador = entity.Id_Utilizador,
                        Regiao = entity.Regiao
                    });

                    ctx.SaveChanges();

                    return new Doente()
                    {
                        Id = doente.Entity.IdDoente,
                        Id_Utilizador = doente.Entity.IdUtilizador,
                        Regiao = doente.Entity.Regiao
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Doente entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var doente = ctx.Doente.Find(entity.Id);
                    ctx.Doente.Remove(doente);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Doente>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.Doente.Select(x => new Doente()
                    {
                        Id = x.IdDoente,
                        Id_Utilizador = x.IdUtilizador,
                        Regiao = x.Regiao
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Doente> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var doente = ctx.Doente.Find(id);

                    return new Doente()
                    {
                        Id = doente.IdDoente,
                        Id_Utilizador = doente.IdUtilizador,
                        Regiao = doente.Regiao
                    };
                }
            }, ct);
        }

        public async Task<Doente> UpdateAsync(Doente entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var doente = ctx.Doente.Find(entity.Id);
                    doente.Regiao = entity.Regiao;
                    doente.IdUtilizador = entity.Id_Utilizador;

                    ctx.Doente.Update(doente);
                    ctx.SaveChanges();

                    return new Doente()
                    {
                        Id = doente.IdDoente,
                        Id_Utilizador = doente.IdUtilizador,
                        Regiao = doente.Regiao
                    };
                }
            },
            ct);
        }
    }
}
