﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using Covid_API.Controllers;
using Covid_API.Interfaces;
using DataBase.Models;
using DataBase.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Covid_API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Registo de dependencias - Dependency injection
            services.AddScoped<IDoente, DoenteController>();
            services.AddScoped<IHospital, HospitalController>();
            services.AddScoped<IInternamento, InternamentoController>();
            services.AddScoped<IModulos, ModulosController>();
            services.AddScoped<IPerfil_Utilizador, Perfil_UtilizadorController>();
            services.AddScoped<IPermissoes, PermissoesController>();
            services.AddScoped<IProfissionais_Saude, Profissionais_SaudeController>();
            services.AddScoped<ITestes, TesteController>();
            services.AddScoped<IUtilizadores, UtilizadoresController>();

            services.AddScoped<IDoenteServices, DoenteServices>();
            services.AddScoped<IHospitalServices, HospitalServices>();
            services.AddScoped<IInternamentoServices, InternamentoServices>();
            services.AddScoped<IModulosServices, ModulosServices>();
            services.AddScoped<IPerfil_UtilizadoresServices, Perfil_UtilizadorServices>();
            services.AddScoped<IPermissoesServices, PermissoesServices>();
            services.AddScoped<IProfissionais_SaudeServices, Profissionais_SaudeServices>();
            services.AddScoped<ITesteServices, TesteServices>();
            services.AddScoped<IUtilizadoresServices, UtilizadoresServices>();

            services.AddScoped<IRepository<Doente>, DoentesRepository>();
            services.AddScoped<IRepository<Hospital>, HospitalRepository>();
            services.AddScoped<IRepository<Internamento>, InternamentoRepository>();
            services.AddScoped<IRepository<Modulos>, ModulosRepository>();
            services.AddScoped<IRepository<Perfil_Utilizador>, Perfil_UtilizadorRepository>();
            services.AddScoped<IRepository<Permissoes>, PermissoesRepository>();
            services.AddScoped<IRepository<Profissionais_Saude>, Profissionais_SaudeRepository>();
            services.AddScoped<IRepository<Teste>, TestesRepository>();
            services.AddScoped<IRepository<Utilizadores>, UtilizadoresRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
