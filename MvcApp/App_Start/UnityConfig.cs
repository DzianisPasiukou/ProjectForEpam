using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using LogicLayer;
using Microsoft.Practices.Unity.InterceptionExtension;
using LoggingManager;
using LogicLayer.CatalogManager;
using LogicLayer.Entities;
using System.Web.Http.Dispatcher;
using LogicLayer.Security;
using LogicLayer.Chat;
using LogicLayer.Users;
using LogicLayer.CatalogManager.ThemeManager.RecordManager;
using System.Configuration;
using LogicLayer.Tasks;

namespace MvcApp.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion
        
        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
         //   var section = ConfigurationManager.GetSection("unity") as UnityConfigurationSection;
          //  section.Containers["container"].Configure(container);
        //   container.LoadConfiguration();
            
           container.AddNewExtension<Interception>();

            container.RegisterType<IChatHelper, ChatHelper>();
            container.RegisterType<IUserHelper, UserHelper>();
            container.RegisterType<ISecurityHelper, SecurityHelper>();
            container.RegisterType<ITaskHelper, TaskHelper>();
            container.RegisterType<IDataBaseManager<Category>, CatalogManager>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<ITree, CatalogManager>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IDataBaseManager<Note>, NoteManager>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IHashCalculator, Sha256HashCalculator>(new InjectionConstructor(), new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IDataBaseManager<User>, UsersInfo>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IDataBaseManager<LikeFile>, LikeFileInfo>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IDataBaseManager<LikeNote>, LikeNoteInfo>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IDataBaseManager<File>, FileManager>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IDataBaseManager<Note_Characteristic>, Note_CharacteristicManager>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
            container.RegisterType<IDataBaseManager<Characteristic>, CharacteristicManager>(new Interceptor<InterfaceInterceptor>(),
            new InterceptionBehavior<LoggingInterceptionBehavior>());
           
        }
    }
}
