using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class TestesRepository : IRepository<Teste>
    {
        public async Task<Teste> CreateAsync(Teste entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var teste = ctx.Teste.Add(new DataModels.Teste()
                    {
                        DataTeste = entity.Data_Teste.DateTime,
                        IdDoente = entity.Id_Doente,
                        IdProfissional = entity.Id_Profissional,
                        TipoTeste = entity.Tipo_Teste,
                        ResultadoTeste = entity.Resultado_Teste
                    });

                    ctx.SaveChanges();

                    return new Teste()
                    {
                        Data_Teste = teste.Entity.DataTeste,
                        Id_Doente = teste.Entity.IdDoente,
                        Id_Profissional = teste.Entity.IdProfissional,
                        Tipo_Teste = teste.Entity.TipoTeste,
                        Resultado_Teste = teste.Entity.ResultadoTeste,
                        Id = teste.Entity.IdTeste
                    };
                }
            },
            ct);
        }

        public async Task DeleteAsync(Teste entity, CancellationToken ct)
        {
            await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var teste = ctx.Teste.Find(entity.Id);
                    ctx.Teste.Remove(teste);

                    ctx.SaveChanges();
                }
            }, ct);
        }

        public async Task<ICollection<Teste>> GetAllAsync(CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    return ctx.Teste.Select(x => new Teste()
                    {
                        Data_Teste = x.DataTeste,
                        Id_Doente = x.IdDoente,
                        Id_Profissional = x.IdProfissional,
                        Tipo_Teste = x.TipoTeste,
                        Resultado_Teste = x.ResultadoTeste,
                        Id = x.IdTeste
                    }).ToList();
                }
            }, ct);
        }

        public async Task<Teste> GetAsync(int id, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var teste = ctx.Teste.Find(id);

                    return new Teste()
                    {
                        Data_Teste = teste.DataTeste,
                        Id_Doente = teste.IdDoente,
                        Id_Profissional = teste.IdProfissional,
                        Tipo_Teste = teste.TipoTeste,
                        Resultado_Teste = teste.ResultadoTeste,
                        Id = teste.IdTeste
                    };
                }
            }, ct);
        }

        public async Task<Teste> UpdateAsync(Teste entity, CancellationToken ct)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new DataModels.DatabaseContext())
                {
                    var teste = ctx.Teste.Find(entity.Id);

                    teste.DataTeste = entity.Data_Teste.DateTime;
                    teste.IdDoente = entity.Id_Doente;
                    teste.IdProfissional = entity.Id_Profissional;
                    teste.TipoTeste = entity.Tipo_Teste;
                    teste.ResultadoTeste = entity.Resultado_Teste;
                    teste.IdTeste = entity.Id;

                    ctx.Teste.Update(teste);
                    ctx.SaveChanges();

                    return new Teste()
                    {
                        Data_Teste = teste.DataTeste,
                        Id_Doente = teste.IdDoente,
                        Id_Profissional = teste.IdProfissional,
                        Tipo_Teste = teste.TipoTeste,
                        Resultado_Teste = teste.ResultadoTeste,
                        Id = teste.IdTeste
                    };
                }
            },
            ct);
        }
    }
}
