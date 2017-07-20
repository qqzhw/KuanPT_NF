using Autofac;
using Autofac.Core;
using IMCustSys.DAL;
using IMCustSys.BLL.Infrastructure;
using IMCustSys.BLL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace IMCustSys.BLL
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //HTTP context and other related stuff  
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

          
            //controllers
           builder.RegisterAssemblyTypes(typeFinder.GetAssemblies().ToArray()).InstancePerLifetimeScope();
             
           
            var sqlcon = ConfigurationManager.ConnectionStrings["ApplicationServices"].ToString();
            IDbConnection connection = new SqlConnection( sqlcon);
             
            builder.RegisterInstance(new DataConnection(connection)).SingleInstance();
          //  builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).WithParameter("context", connection).InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CampaignService>().As<ICampaignService>().InstancePerLifetimeScope();
            builder.RegisterType<PictureService>().As<IPictureService>().InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<ShopService>().As<IShopService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderService>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<ChannelService>().As<IChannelService>().InstancePerLifetimeScope();
            builder.RegisterType<ExportManager>().As<IExportManager>().InstancePerLifetimeScope();
            builder.RegisterType<LotteryService>().As<ILotteryService>().InstancePerLifetimeScope();
            
        }

        /// <summary>
        /// ×¢ÈëË³Ðò
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    } 
  
}
