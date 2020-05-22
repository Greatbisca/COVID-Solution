using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class PermissoesRepository : IRepository<Permissoes>
    {
        public async Task<Permissoes> CreateAsync(Permissoes entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var permissao = ctx.Permissoes.Add(new DataModels.Permissoes()
                    {
                        Criar = entity.Criar ? "S" : "N",
                        Eliminar = entity.Eliminar ? "S" : "N",
                        Escrever = entity.Escrever ? "S" : "N",
                        Ler = entity.Ler ? "S" : "N",
                        IdModulo = entity.Id_Modulo,
                        IdPerfilUtilizador = entity.Id_Perfil_Utilizador
                    });

                    ctx.SaveChanges();

                    return new Permissoes()
                    {
                        Criar = permissao.Entity.Criar == "S",
                        Eliminar = permissao.Entity.Eliminar == "S",
                        Escrever = permissao.Entity.Escrever == "S",
                        Ler = permissao.Entity.Ler == "S",
                        Id_Modulo = permissao.Entity.IdModulo,
                        Id_Perfil_Utilizador = permissao.Entity.IdPerfilUtilizador,
                        Id = permissao.Entity.IdPermissao
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Permissoes entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var permissao = ctx.Permissoes.Find(entity.Id);
                    ctx.Permissoes.Remove(permissao);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Permissoes>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.Permissoes.Select(x => new Permissoes()
                    {
                        Criar = x.Criar == "S",
                        Eliminar = x.Eliminar == "S",
                        Escrever = x.Escrever == "S",
                        Ler = x.Ler == "S",
                        Id_Modulo = x.IdModulo,
                        Id_Perfil_Utilizador = x.IdPerfilUtilizador,
                        Id = x.IdPermissao
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Permissoes> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var permissao = ctx.Permissoes.Find(id);

                    return new Permissoes()
                    {
                        Criar = permissao.Criar == "S",
                        Eliminar = permissao.Eliminar == "S",
                        Escrever = permissao.Escrever == "S",
                        Ler = permissao.Ler == "S",
                        Id_Modulo = permissao.IdModulo,
                        Id_Perfil_Utilizador = permissao.IdPerfilUtilizador,
                        Id = permissao.IdPermissao
                    };
                }
            }, ct);
        }

        public async Task<Permissoes> UpdateAsync(Permissoes entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var permissao = ctx.Permissoes.Find(entity.Id);

                    permissao.IdPermissao = entity.Id;
                    permissao.IdModulo = entity.Id_Modulo;
                    permissao.IdPerfilUtilizador = entity.Id_Perfil_Utilizador;
                    permissao.Ler = entity.Ler ? "S" : "N";
                    permissao.Criar = entity.Criar ? "S" : "N";
                    permissao.Eliminar = entity.Eliminar ? "S" : "N";
                    permissao.Escrever = entity.Escrever ? "S" : "N";

                    ctx.Permissoes.Update(permissao);
                    ctx.SaveChanges();

                    return new Permissoes()
                    {
                        Criar = permissao.Criar == "S",
                        Eliminar = permissao.Eliminar == "S",
                        Escrever = permissao.Escrever == "S",
                        Ler = permissao.Ler == "S",
                        Id_Modulo = permissao.IdModulo,
                        Id_Perfil_Utilizador = permissao.IdPerfilUtilizador,
                        Id = permissao.IdPermissao
                    };
                }
            },
            ct);
        }
    }
}
