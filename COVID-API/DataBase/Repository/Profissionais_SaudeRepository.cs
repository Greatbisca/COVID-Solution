using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class Profissionais_SaudeRepository : IRepository<Profissionais_Saude>
    {
        public async Task<Profissionais_Saude> CreateAsync(Profissionais_Saude entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var profissional = ctx.ProfissionaisDeSaude.Add(new DataModels.ProfissionaisDeSaude()
                    {
                        IdHospital = entity.Id_Hospital,
                        IdUtilizador = entity.Id_Utilizador,
                        Profissao = entity.Profissao
                    });

                    ctx.SaveChanges();

                    return new Profissionais_Saude()
                    {
                        Id_Hospital = profissional.Entity.IdHospital.GetValueOrDefault(),
                        Id_Utilizador = profissional.Entity.IdUtilizador,
                        Profissao = profissional.Entity.Profissao
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Profissionais_Saude entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var profissional = ctx.ProfissionaisDeSaude.Find(entity.Id);
                    ctx.ProfissionaisDeSaude.Remove(profissional);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Profissionais_Saude>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.ProfissionaisDeSaude.Select(x => new Profissionais_Saude()
                    {
                        Id_Hospital = x.IdHospital.GetValueOrDefault(),
                        Id_Utilizador = x.IdUtilizador,
                        Profissao = x.Profissao
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Profissionais_Saude> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var profissional = ctx.ProfissionaisDeSaude.Find(id);

                    return new Profissionais_Saude()
                    {
                        Id_Hospital = profissional.IdHospital.GetValueOrDefault(),
                        Id_Utilizador = profissional.IdUtilizador,
                        Profissao = profissional.Profissao
                    };
                }
            }, ct);
        }

        public async Task<Profissionais_Saude> UpdateAsync(Profissionais_Saude entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var profissional = ctx.ProfissionaisDeSaude.Find(entity.Id);

                    profissional.IdHospital = entity.Id_Hospital;
                    profissional.IdUtilizador = entity.Id_Utilizador;
                    profissional.Profissao = entity.Profissao;

                    ctx.ProfissionaisDeSaude.Update(profissional);
                    ctx.SaveChanges();

                    return new Profissionais_Saude()
                    {
                        Id_Hospital = profissional.IdHospital.GetValueOrDefault(),
                        Id_Utilizador = profissional.IdUtilizador,
                        Profissao = profissional.Profissao
                    };
                }
            },
            ct);
        }
    }
}
