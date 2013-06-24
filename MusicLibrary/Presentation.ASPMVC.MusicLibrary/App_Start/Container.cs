using Microsoft.Practices.Unity;
using MusicaManager.Application.MusicLibrary.SongModule.Services;
using MusicManager.Domain.MusicLibrary.SongModule.Aggregates.SongAgg;
using MusicManager.Infrastructure.Crosscutting.Adapter;
using MusicManager.Infrastructure.Crosscutting.NetFramework.Adapter;
using MusicManager.Infrastructure.Crosscutting.NetFramework.Validator;
using MusicManager.Infrastructure.Crosscutting.Validator;
using MusicManager.Infrastructure.MusicLibrary.SongModule.Repositories;
using MusicManager.Infrastructure.MusicLibrary.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicManager.Presentation.ASPMVC.MusicLibrary.App_Start
{
   
            /// <summary>
    /// DI container accessor
    /// </summary>
    public static class Container
    {
        #region Properties

        static  IUnityContainer _currentContainer;

        /// <summary>
        /// Get the current configured container
        /// </summary>
        /// <returns>Configured container</returns>
        public static IUnityContainer Current
        {
            get
            {
                return _currentContainer;
            }
        }

        #endregion

        #region Constructor
        
        static Container()
        {
            ConfigureContainer();

            ConfigureFactories();
        }

        #endregion

        #region Methods

        static void ConfigureContainer()
        {
            /*
             * Add here the code configuration or the call to configure the container 
             * using the application configuration file
             */

            _currentContainer = new UnityContainer();
            
            
            //-> Unit of Work and repositories
            _currentContainer.RegisterType(typeof(MainMLUnitOfWork), new PerResolveLifetimeManager());
            

            _currentContainer.RegisterType<ISongRepository, SongRepository>();

            //-> Adapters
            _currentContainer.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());

            

            //-> Application services
            _currentContainer.RegisterType<ISongService, SongService>();

            
        }


        static void ConfigureFactories()
        {
            
            EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            var typeAdapterFactory = _currentContainer.Resolve<ITypeAdapterFactory>();
            TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        #endregion
    }
}