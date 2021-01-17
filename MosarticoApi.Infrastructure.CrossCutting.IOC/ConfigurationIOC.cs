using Autofac;
using MosarticoApi.Application.Interface;
using MosarticoApi.Application.Service;
using MosarticoApi.Domain.Core.Interfaces.Repositorys;
using MosarticoApi.Domain.Core.Interfaces.Services;
using MosarticoApi.Domain.Services.Services;
using MosarticoApi.Infrastructure.Repository.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MosarticoApi.Infrastruture.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceUsuario>().As<IApplicationServiceUsuario>();
            builder.RegisterType<ApplicationServiceArte>().As<IApplicationServiceArte>();
            builder.RegisterType<ApplicationServiceEndereco>().As<IApplicationServiceEndereco>();
            builder.RegisterType<ApplicationServiceTelefone>().As<IApplicationServiceTelefone>();
            builder.RegisterType<ApplicationServicePerfil>().As<IApplicationServicePerfil>();
            builder.RegisterType<ApplicationServiceOng>().As<IApplicationServiceOng>();
            builder.RegisterType<ApplicationServiceOficina>().As<IApplicationServiceOficina>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();
            builder.RegisterType<ServiceArte>().As<IServiceArte>();
            builder.RegisterType<ServiceEndereco>().As<IServiceEndereco>();
            builder.RegisterType<ServiceTelefone>().As<IServiceTelefone>();
            builder.RegisterType<ServicePerfil>().As<IServicePerfil>();
            builder.RegisterType<ServiceTipoArte>().As<IServiceTipoArte>();
            builder.RegisterType<ServiceEmailSender>().As<IEmailSender>();
            builder.RegisterType<ServiceOficina>().As<IServiceOficina>();
            builder.RegisterType<ServiceOng>().As<IServiceOng>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();
            builder.RegisterType<RepositoryArte>().As<IRepositoryArte>();
            builder.RegisterType<RepositoryEndereco>().As<IRepositoryEndereco>();
            builder.RegisterType<RepositoryTelefone>().As<IRepositoryTelefone>();
            builder.RegisterType<RepositoryPerfil>().As<IRepositoryPerfil>();
            builder.RegisterType<RepositoryTipoArte>().As<IRepositoryTipoArte>();
            builder.RegisterType<RepositoryImagemArte>().As<IRepositoryImagemArte>();
            builder.RegisterType<RepositoryOng>().As<IRepositoryOng>();
            builder.RegisterType<RepositoryOficina>().As<IRepositoryOficina>();
            #endregion

            #endregion

        }
    }
}
