using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class Perfil_UtilizadorRepository : IRepository<Perfil_Utilizador>
    {
        public async Task<Perfil_Utilizador> CreateAsync(Perfil_Utilizador entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var modulo = ctx.PerfilUtilizador.Add(new DataModels.PerfilUtilizador()
                    {
                        Nome = entity.Nome
                    });

                    ctx.SaveChanges();

                    return new Perfil_Utilizador()
                    {
                        Id = modulo.Entity.IdPerfilUtilizador,
                        Nome = modulo.Entity.Nome
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Perfil_Utilizador entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var perfil = ctx.PerfilUtilizador.Find(entity.Id);
                    ctx.PerfilUtilizador.Remove(perfil);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Perfil_Utilizador>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.PerfilUtilizador.Select(x => new Perfil_Utilizador()
                    {
                        Id = x.IdPerfilUtilizador,
                        Nome = x.Nome
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Perfil_Utilizador> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var perfil = ctx.PerfilUtilizador.Find(id);

                    return new Perfil_Utilizador()
                    {
                        Id = perfil.IdPerfilUtilizador,
                        Nome = perfil.Nome
                    };
                }
            }, ct);
        }

        public async Task<Perfil_Utilizador> UpdateAsync(Perfil_Utilizador entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var perfil = ctx.PerfilUtilizador.Find(entity.Id);

                    perfil.IdPerfilUtilizador = entity.Id;
                    perfil.Nome = entity.Nome;

                    ctx.PerfilUtilizador.Update(perfil);
                    ctx.SaveChanges();

                    return new Perfil_Utilizador()
                    {
                        Id = perfil.IdPerfilUtilizador,
                        Nome = perfil.Nome
                    };
                }
            },
            ct);
        }
    }
}
