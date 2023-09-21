using Autofac;
using MasterCRUD.Web.Data;

namespace MasterCRUD.Web
{
    public class WebModule:Module
    {
        private readonly string _connectionString;
        public WebModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)              
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
