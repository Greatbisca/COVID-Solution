using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class UtilizadoresRepository : IRepository<Utilizadores>
    {
        public async Task<Utilizadores> CreateAsync(Utilizadores entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var utilizador = ctx.Utilizador.Add(new DataModels.Utilizador()
                    {
                        Cc = entity.CC,
                        IdPerfilUtilizador = entity.Id_Perfil_Utilizador,
                        Idade = entity.Idade,
                        Morada = entity.Morada,
                        Nib = entity.NIB,
                        Nome = entity.Nome,
                        Sexo = entity.Sexo == "M" ? 0: 1,
                        Username = entity.Username
                    });

                    ctx.SaveChanges();

                    return new Utilizadores()
                    {
                        CC = utilizador.Entity.Cc,
                        Id_Perfil_Utilizador = utilizador.Entity.IdPerfilUtilizador,
                        Idade = utilizador.Entity.Idade,
                        Morada = utilizador.Entity.Morada,
                        NIB = utilizador.Entity.Nib,
                        Nome = utilizador.Entity.Nome,
                        Sexo = utilizador.Entity.Sexo == 0 ? "M" : "F",
                        Username = utilizador.Entity.Username
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Utilizadores entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var utilizador = ctx.Utilizador.Find(entity.Id);
                    ctx.Utilizador.Remove(utilizador);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Utilizadores>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.Utilizador.Select(x => new Utilizadores()
                    {
                        CC = x.Cc,
                        Id_Perfil_Utilizador = x.IdPerfilUtilizador,
                        Idade = x.Idade,
                        Morada = x.Morada,
                        NIB = x.Nib,
                        Nome = x.Nome,
                        Sexo = x.Sexo == 0 ? "M" : "F",
                        Username = x.Username
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Utilizadores> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var utilizador = ctx.Utilizador.Find(id);

                    return new Utilizadores()
                    {
                        CC = utilizador.Cc,
                        Id_Perfil_Utilizador = utilizador.IdPerfilUtilizador,
                        Idade = utilizador.Idade,
                        Morada = utilizador.Morada,
                        NIB = utilizador.Nib,
                        Nome = utilizador.Nome,
                        Sexo = utilizador.Sexo == 0 ? "M" : "F",
                        Username = utilizador.Username
                    };
                }
            }, ct);
        }

        public async Task<Utilizadores> UpdateAsync(Utilizadores entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var utilizador = ctx.Utilizador.Find(entity.Id);

                    utilizador.Cc = entity.CC;
                    utilizador.IdPerfilUtilizador = entity.Id_Perfil_Utilizador;
                    utilizador.Idade = entity.Idade;
                    utilizador.Morada = entity.Morada;
                    utilizador.Nib = entity.NIB;
                    utilizador.Nome = entity.Nome;
                    utilizador.Sexo = entity.Sexo == "M" ? 0 : 1;
                    utilizador.Username = entity.Username;

                    ctx.Utilizador.Update(utilizador);
                    ctx.SaveChanges();

                    return new Utilizadores()
                    {
                        CC = utilizador.Cc,
                        Id_Perfil_Utilizador = utilizador.IdPerfilUtilizador,
                        Idade = utilizador.Idade,
                        Morada = utilizador.Morada,
                        NIB = utilizador.Nib,
                        Nome = utilizador.Nome,
                        Sexo = utilizador.Sexo == 0 ? "M" : "F",
                        Username = utilizador.Username
                    };
                }
            },
            ct);
        }
    }
}
